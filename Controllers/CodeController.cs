using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_IoT.Data;
using Web_IoT.Models;

namespace Web_IoT.Controllers
{
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
                title = code.Title,
                language = code.Language,
                content = code.Content
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCode(int id, [FromBody] CodeUpdateModel model)
        {
            var code = await _context.DeviceCodes.FindAsync(id);
            if (code == null)
                return NotFound();

            code.Content = model.Content;
            code.Language = model.Language;
            await _context.SaveChangesAsync();

            return Ok();
        }

        public class CodeUpdateModel
        {
            public string Content { get; set; }
            public string Language { get; set; }
        }
    }
}
