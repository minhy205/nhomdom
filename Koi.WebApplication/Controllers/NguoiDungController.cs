using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;
using Koi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        // GET: api/NguoiDung/{khachHangID}
        [HttpGet("{khachHangID}")]
        public async Task<ActionResult<NguoiDung>> GetByIdAsync(int khachHangID)
        {
            var nguoiDung = await _nguoiDungService.GetByIdAsync(khachHangID);
            if (nguoiDung == null)
            {
                return NotFound();
            }
            return Ok(nguoiDung);
        }

        // GET: api/NguoiDung/ByUser/{userID}
        [HttpGet("ByUser/{userID}")]
        public async Task<ActionResult<IEnumerable<NguoiDung>>> GetByUserIdAsync(int userID)
        {
            var nguoiDungs = await _nguoiDungService.GetByUserIdAsync(userID);
            return Ok(nguoiDungs);
        }

        // POST: api/NguoiDung
        [HttpPost]
       

        // PUT: api/NguoiDung/{khachHangID}
        [HttpPut("{khachHangID}")]
       

        // DELETE: api/NguoiDung/{khachHangID}
        [HttpDelete("{khachHangID}")]
        public async Task<IActionResult> DeleteAsync(int khachHangID)
        {
            var result = await _nguoiDungService.DeleteAsync(khachHangID);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
