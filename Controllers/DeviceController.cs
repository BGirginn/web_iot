using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_IoT.Data;
using Web_IoT.Models;

namespace Web_IoT.Controllers
{
    public class DeviceController : Controller
    {
        private readonly AppDbContext _context;

        public DeviceController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Tüm cihazları ve kodlarını getir (giriş kontrolü yok artık)
            var devices = await _context.Devices
                .Include(d => d.Codes)
                .ToListAsync();

            return View(devices);
        }
    }
}
