using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;
using Koi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Koi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LichSuKyGuiController : ControllerBase
    {
        private readonly ILichSuKyGuiService _lichSuKyGuiService;

        public LichSuKyGuiController(ILichSuKyGuiService lichSuKyGuiService)
        {
            _lichSuKyGuiService = lichSuKyGuiService;
        }

        // GET: api/LichSuKyGui/{lichSuKyGuiID}
        [HttpGet("{lichSuKyGuiID}")]
        public async Task<ActionResult<LichSuKyGui>> GetByIdAsync(int lichSuKyGuiID)
        {
            var lichSuKyGui = await _lichSuKyGuiService.GetByIdAsync(lichSuKyGuiID);
            if (lichSuKyGui == null)
            {
                return NotFound();
            }
            return Ok(lichSuKyGui);
        }

        // GET: api/LichSuKyGui
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LichSuKyGui>>> GetAllAsync()
        {
            var lichSuKyGuis = await _lichSuKyGuiService.GetAllAsync();
            return Ok(lichSuKyGuis);
        }

        // POST: api/LichSuKyGui
        [HttpPost]
        

        // PUT: api/LichSuKyGui/{lichSuKyGuiID}
        [HttpPut("{lichSuKyGuiID}")]
        

        // DELETE: api/LichSuKyGui/{lichSuKyGuiID}
        [HttpDelete("{lichSuKyGuiID}")]
        public async Task<IActionResult> DeleteAsync(int lichSuKyGuiID)
        {
            var result = await _lichSuKyGuiService.DeleteAsync(lichSuKyGuiID);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
