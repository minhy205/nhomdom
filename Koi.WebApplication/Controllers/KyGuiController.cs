using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;
using Koi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Koi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KyGuiController : ControllerBase
    {
        private readonly IKyGuiService _kyGuiService;

        public KyGuiController(IKyGuiService kyGuiService)
        {
            _kyGuiService = kyGuiService;
        }

        // GET: api/KyGui/{kyGuiID}
        [HttpGet("{kyGuiID}")]
        public async Task<ActionResult<KyGui>> GetByIdAsync(int kyGuiID)
        {
            var kyGui = await _kyGuiService.GetByIdAsync(kyGuiID);
            if (kyGui == null)
            {
                return NotFound();
            }
            return Ok(kyGui);
        }

        // GET: api/KyGui/ByLichSuKyGui/{lichSuKyGuiID}
        [HttpGet("ByLichSuKyGui/{lichSuKyGuiID}")]
        public async Task<ActionResult<IEnumerable<KyGui>>> GetByLichSuKyGuiIdAsync(int lichSuKyGuiID)
        {
            var kyGuiList = await _kyGuiService.GetByLichSuKyGuiIdAsync(lichSuKyGuiID);
            return Ok(kyGuiList);
        }

        // POST: api/KyGui
        [HttpPost]
      

        // PUT: api/KyGui/{kyGuiID}
        [HttpPut("{kyGuiID}")]
       

        // DELETE: api/KyGui/{kyGuiID}
        [HttpDelete("{kyGuiID}")]
        public async Task<IActionResult> DeleteAsync(int kyGuiID)
        {
            var result = await _kyGuiService.DeleteAsync(kyGuiID);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
