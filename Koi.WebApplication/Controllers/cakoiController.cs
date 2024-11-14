using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;
using Koi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Koi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaKoiController : ControllerBase
    {
        private readonly ICaKoiService _caKoiService;

        public CaKoiController(ICaKoiService caKoiService)
        {
            _caKoiService = caKoiService;
        }

        // GET: api/CaKoi/{caKoiId}
        [HttpGet("{caKoiId}")]
        public async Task<ActionResult<CaKoi>> GetByIdAsync(int caKoiId)
        {
            var caKoi = await _caKoiService.GetByIdAsync(caKoiId);
            if (caKoi == null)
            {
                return NotFound();
            }
            return Ok(caKoi);
        }

        // GET: api/CaKoi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaKoi>>> GetAllAsync()
        {
            var caKoiList = await _caKoiService.GetAllAsync();
            return Ok(caKoiList);
        }

        // POST: api/CaKoi
        [HttpPost]
        public async Task<ActionResult<CaKoi>> AddAsync(CaKoi caKoi)
        {
            var addedCaKoi = await _caKoiService.AddAsync(caKoi);
            return CreatedAtAction(nameof(GetByIdAsync), new { caKoiId = addedCaKoi.CaKoiId }, addedCaKoi);  // Chỉnh lại để sử dụng CaKoiId
        }

        // PUT: api/CaKoi/{caKoiId}
        [HttpPut("{caKoiId}")]
        public async Task<IActionResult> UpdateAsync(int caKoiId, CaKoi caKoi)
        {
            if (caKoiId != caKoi.CaKoiId)  // Sử dụng CaKoiId thay vì Id
            {
                return BadRequest();
            }

            await _caKoiService.UpdateAsync(caKoi);
            return NoContent();
        }

        // DELETE: api/CaKoi/{caKoiId}
        [HttpDelete("{caKoiId}")]
        public async Task<IActionResult> DeleteAsync(int caKoiId)
        {
            var deleted = await _caKoiService.DeleteAsync(caKoiId);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
