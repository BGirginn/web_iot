using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO.Ports;
using WebIot.Data;
using WebIot.Models;
using WebIot.Services;

namespace WebIot.Controllers
{
    [Authorize]
    public class DeviceController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ISerialPortService _serialPortService;
        private readonly ILogger<DeviceController> _logger;

        public DeviceController(
            AppDbContext context,
            ISerialPortService serialPortService,
            ILogger<DeviceController> logger)
        {
            _context = context;
            _serialPortService = serialPortService;
            _logger = logger;
        }

        // GET: Device
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var devices = await _context.Devices
                .Where(d => d.UserId == userId)
                .ToListAsync();
            return View(devices);
        }

        // GET: Device/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Devices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // GET: Device/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Device/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,PortName,BaudRate,DeviceType,Description")] Device device)
        {
            if (ModelState.IsValid)
            {
                device.UserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                device.CreatedAt = DateTime.UtcNow;
                _context.Add(device);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(device);
        }

        // GET: Device/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }
            return View(device);
        }

        // POST: Device/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PortName,BaudRate,DeviceType,Description,IsActive")] Device device)
        {
            if (id != device.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(device);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceExists(device.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(device);
        }

        // GET: Device/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Devices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // POST: Device/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device != null)
            {
                _context.Devices.Remove(device);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Device/Connect/5
        [HttpPost]
        public async Task<IActionResult> Connect(int id)
        {
            var device = await _context.Devices.FindAsync(id);
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

            return Json(new { success = result });
        }

        // POST: Device/Disconnect/5
        [HttpPost]
        public async Task<IActionResult> Disconnect(int id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            await _serialPortService.DisconnectFromDevice(device);
            return Json(new { success = true });
        }

        // POST: Device/SendCommand/5
        [HttpPost]
        public async Task<IActionResult> SendCommand(int id, string command)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            await _serialPortService.SendCommand(device, command);
            return Json(new { success = true });
        }

        // GET: Device/GetAvailablePorts
        [HttpGet]
        public IActionResult GetAvailablePorts()
        {
            var ports = SerialPort.GetPortNames();
            return Json(ports);
        }

        private bool DeviceExists(int id)
        {
            return _context.Devices.Any(e => e.Id == id);
        }
    }
} 