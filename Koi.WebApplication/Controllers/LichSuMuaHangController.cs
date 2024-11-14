using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;
using Koi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Koi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LichSuMuaHangController : ControllerBase
    {
        private readonly ILichSuMuaHangService _lichSuMuaHangService;

        public LichSuMuaHangController(ILichSuMuaHangService lichSuMuaHangService)
        {
            _lichSuMuaHangService = lichSuMuaHangService;
        }

        // GET: api/LichSuMuaHang/{muaHangID}
        [HttpGet("{muaHangID}")]
        public async Task<ActionResult<LichSuMuaHang>> GetByIdAsync(int muaHangID)
        {
            var lichSuMuaHang = await _lichSuMuaHangService.GetByIdAsync(muaHangID);
            if (lichSuMuaHang == null)
            {
                return NotFound();
            }
            return Ok(lichSuMuaHang);
        }

        // GET: api/LichSuMuaHang/ByKhachHang/{maKhachHang}
        [HttpGet("ByKhachHang/{maKhachHang}")]
        public async Task<ActionResult<IEnumerable<LichSuMuaHang>>> GetByKhachHangIdAsync(int maKhachHang)
        {
            var lichSuMuaHangList = await _lichSuMuaHangService.GetByKhachHangIdAsync(maKhachHang);
            return Ok(lichSuMuaHangList);
        }

        // POST: api/LichSuMuaHang
        [HttpPost]
        

        // PUT: api/LichSuMuaHang/{muaHangID}
        [HttpPut("{muaHangID}")]
        

        // DELETE: api/LichSuMuaHang/{muaHangID}
        [HttpDelete("{muaHangID}")]
        public async Task<IActionResult> DeleteAsync(int muaHangID)
        {
            var result = await _lichSuMuaHangService.DeleteAsync(muaHangID);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
