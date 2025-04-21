using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Web_IoT.Data;
using Microsoft.AspNetCore.Identity;
using Web_IoT.Models;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web_IoT API", Version = "v1" });
});

// 🔧 Doğrudan bağlantı stringi burada
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=BGIRGIN\\SQLEXPRESS;Database=WebIoTDB;Trusted_Connection=True;TrustServerCertificate=True;"));

// Identity sistemi tanımlı AppUser ile aktif
builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication(); // Kimlik doğrulama
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // Identity sayfaları için şart

app.Run();
