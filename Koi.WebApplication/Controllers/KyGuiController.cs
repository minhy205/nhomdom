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
            var result = await _kyGuiService.GetByIdAsync(kyGuiID);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }       

        // DELETE: api/KyGui/{kyGuiID}
        [HttpDelete("{kyGuiID}")]
        public async Task<IActionResult> DeleteAsync(int kyGuiID)
        {
            var success = await _kyGuiService.DeleteAsync(kyGuiID);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
