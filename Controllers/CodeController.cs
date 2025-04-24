using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_IoT.Data;

namespace Web_IoT.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CodeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CodeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCode(int id)
        {
            var code = await _context.DeviceCodes.FindAsync(id);

            if (code == null)
                return NotFound();

            return Ok(new
            {
                code.Id,
                code.Title,
                code.Language,
                code.Content
            });
        }
    }
}
