using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_IoT.Data;
using Web_IoT.Models;

namespace Web_IoT.Controllers
{
    // [Authorize]
    public class DeviceController : Controller
    {
        private readonly AppDbContext _context;

        public DeviceController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Giriş yapan kullanıcının ID'si
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized(); // Kullanıcı yoksa erişim engellenir

            // Bu kullanıcıya ait cihazları ve içindeki kodları çek
            var devices = await _context.Devices
                .Include(d => d.Codes)
                .Where(d => d.UserId == userId)
                .ToListAsync();

            return View(devices);
        }
    }
}
