using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;
using Koi.Services.Interfaces;

namespace Koi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhGiaController : ControllerBase
    {
        private readonly IDanhGiaService _danhGiaService;

        public DanhGiaController(IDanhGiaService danhGiaService)
        {
            _danhGiaService = danhGiaService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DanhGia>> GetById(int id)
        {
            var danhGia = await _danhGiaService.GetByIdAsync(id);
            if (danhGia == null)
            {
                return NotFound();
            }
            return Ok(danhGia);
        }

        [HttpGet("caKoi/{caKoiId}")]
        public async Task<ActionResult<IEnumerable<DanhGia>>> GetByCaKoiId(int caKoiId)
        {
            var danhGias = await _danhGiaService.GetByCaKoiIdAsync(caKoiId);
            return Ok(danhGias);
        }

        [HttpPost]


        [HttpPut("{id}")]
       

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _danhGiaService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
