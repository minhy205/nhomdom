using Microsoft.AspNetCore.Mvc;
using Koi.Services.Interfaces;
using Koi.Repositories.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Koi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungController : ControllerBase
    {
        private readonly INguoiDungService _nguoiDungService;

        public NguoiDungController(INguoiDungService nguoiDungService)
        {
            _nguoiDungService = nguoiDungService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NguoiDung>> GetByIdAsync(int id)
        {
            var result = await _nguoiDungService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("by-user/{userId}")]
        public async Task<ActionResult<IEnumerable<NguoiDung>>> GetByUserIdAsync(int userId)
        {
            var result = await _nguoiDungService.GetByUserIdAsync(userId);
            return Ok(result);
        }

       

        

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var success = await _nguoiDungService.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
