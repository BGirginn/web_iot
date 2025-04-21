using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_IoT.Data;
using Web_IoT.Models;
using System.Threading.Tasks;

namespace Web_IoT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DeviceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDevices()
        {
            return Ok(await _context.Devices.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddDevice([FromBody] Device device)
        {
            _context.Devices.Add(device);
            await _context.SaveChangesAsync();
            return Ok(device);
        }
    }
}
