using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;
using Koi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Koi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangCuaToiController : ControllerBase
    {
        private readonly IGioHangCuaToiService _gioHangCuaToiService;

        public GioHangCuaToiController(IGioHangCuaToiService gioHangCuaToiService)
        {
            _gioHangCuaToiService = gioHangCuaToiService;
        }

        // GET: api/GioHangCuaToi/{gioHangID}
        [HttpGet("{gioHangID}")]
        public async Task<ActionResult<GioHangCuaToi>> GetByIdAsync(int gioHangID)
        {
            var gioHang = await _gioHangCuaToiService.GetByIdAsync(gioHangID);
            if (gioHang == null)
            {
                return NotFound();
            }
            return Ok(gioHang);
        }

        // GET: api/GioHangCuaToi/ByCaKoi/{caKoiID}
        [HttpGet("ByCaKoi/{caKoiID}")]
        public async Task<ActionResult<IEnumerable<GioHangCuaToi>>> GetByCaKoiIdAsync(int caKoiID)
        {
            var gioHangList = await _gioHangCuaToiService.GetByCaKoiIdAsync(caKoiID);
            return Ok(gioHangList);
        }

        // POST: api/GioHangCuaToi
        [HttpPost]
        


        // PUT: api/GioHangCuaToi/{gioHangID}
        [HttpPut("{gioHangID}")]
    
        

        // DELETE: api/GioHangCuaToi/{gioHangID}
        [HttpDelete("{gioHangID}")]
        public async Task<IActionResult> DeleteAsync(int gioHangID)
        {
            var result = await _gioHangCuaToiService.DeleteAsync(gioHangID);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
