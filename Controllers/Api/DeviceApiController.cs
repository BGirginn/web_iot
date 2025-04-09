using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebIot.Data;
using WebIot.Models;
using WebIot.Services;

namespace WebIot.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DeviceApiController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ISerialPortService _serialPortService;
        private readonly ILogger<DeviceApiController> _logger;

        public DeviceApiController(
            AppDbContext context,
            ISerialPortService serialPortService,
            ILogger<DeviceApiController> logger)
        {
            _context = context;
            _serialPortService = serialPortService;
            _logger = logger;
        }

        // GET: api/DeviceApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevices()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            return await _context.Devices
                .Where(d => d.UserId == userId)
                .ToListAsync();
        }

        // GET: api/DeviceApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Device>> GetDevice(int id)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var device = await _context.Devices
                .FirstOrDefaultAsync(d => d.Id == id && d.UserId == userId);

            if (device == null)
            {
                return NotFound();
            }

            return device;
        }

        // POST: api/DeviceApi/5/connect
        [HttpPost("{id}/connect")]
        public async Task<IActionResult> ConnectDevice(int id)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var device = await _context.Devices
                .FirstOrDefaultAsync(d => d.Id == id && d.UserId == userId);

            if (device == null)
            {
                return NotFound();
            }

            var result = await _serialPortService.ConnectToDevice(device);
            if (result)
            {
                device.LastConnectedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }

            return Ok(new { success = result });
        }

        // POST: api/DeviceApi/5/disconnect
        [HttpPost("{id}/disconnect")]
        public async Task<IActionResult> DisconnectDevice(int id)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var device = await _context.Devices
                .FirstOrDefaultAsync(d => d.Id == id && d.UserId == userId);

            if (device == null)
            {
                return NotFound();
            }

            await _serialPortService.DisconnectFromDevice(device);
            return Ok(new { success = true });
        }

        // POST: api/DeviceApi/5/command
        [HttpPost("{id}/command")]
        public async Task<IActionResult> SendCommand(int id, [FromBody] string command)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var device = await _context.Devices
                .FirstOrDefaultAsync(d => d.Id == id && d.UserId == userId);

            if (device == null)
            {
                return NotFound();
            }

            await _serialPortService.SendCommand(device, command);
            return Ok(new { success = true });
        }

        // GET: api/DeviceApi/5/data
        [HttpGet("{id}/data")]
        public async Task<IActionResult> GetDeviceData(int id)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var device = await _context.Devices
                .FirstOrDefaultAsync(d => d.Id == id && d.UserId == userId);

            if (device == null)
            {
                return NotFound();
            }

            var data = await _serialPortService.ReadData(device);
            return Ok(new { data });
        }
    }
} 