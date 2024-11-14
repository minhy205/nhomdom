using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;
using Koi.Repositories.Interfaces;
using Koi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Koi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly ISanPhamServices _sanPhamServices;

        public SanPhamController(ISanPhamServices sanPhamServices)
        {
            _sanPhamServices = sanPhamServices;
        }

        // GET: api/SanPham/{sanPhamID}
        [HttpGet("{sanPhamID}")]
        public async Task<ActionResult<SanPham>> GetByIdAsync(int sanPhamID)
        {
            var sanPham = await _sanPhamServices.GetByIdAsync(sanPhamID);
            if (sanPham == null)
            {
                return NotFound();
            }
            return Ok(sanPham);
        }

        // GET: api/SanPham
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SanPham>>> GetAllAsync()
        {
            var sanPhams = await _sanPhamServices.GetAllAsync();
            return Ok(sanPhams);
        }

        // POST: api/SanPham
        [HttpPost]
        

        // PUT: api/SanPham/{sanPhamID}
        [HttpPut("{sanPhamID}")]
        

        // DELETE: api/SanPham/{sanPhamID}
        [HttpDelete("{sanPhamID}")]
        public async Task<IActionResult> DeleteAsync(int sanPhamID)
        {
            var result = await _sanPhamServices.DeleteAsync(sanPhamID);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
