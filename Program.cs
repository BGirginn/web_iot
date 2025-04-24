using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Web_IoT.Data;
using Web_IoT.Models;

var builder = WebApplication.CreateBuilder(args);

// --- Localization Services ---
builder.Services.AddLocalization(opts => opts.ResourcesPath = "Resources");

var supportedCultures = new[]
{
    new CultureInfo("tr-TR"),
    new CultureInfo("en-US")
};

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("tr-TR");
    options.SupportedCultures = supportedCultures.ToList();
    options.SupportedUICultures = supportedCultures.ToList();
});
// --- /Localization ---

// --- MVC + Razor + Localization ---
builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();
builder.Services.AddRazorPages();
// --- /MVC + Razor + Localization ---

// --- Swagger / API Explorer ---
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web_IoT API", Version = "v1" });
});
// --- /Swagger ---

// --- EF Core & SQL Server ---
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=BGIRGIN\\SQLEXPRESS;Database=WebIoTDB;Trusted_Connection=True;TrustServerCertificate=True;"));
// --- /EF Core ---

// --- ASP.NET Core Identity ---
builder.Services.AddDefaultIdentity<AppUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
    .AddEntityFrameworkStores<AppDbContext>();
// --- /Identity ---

var app = builder.Build();

// --- Localization Middleware ---
var locOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;
app.UseRequestLocalization(locOptions);
// --- /Localization Middleware ---

// --- Swagger UI (Development only) ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// --- /Swagger UI ---

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// --- Routing ---
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
// --- /Routing ---

app.Run();
