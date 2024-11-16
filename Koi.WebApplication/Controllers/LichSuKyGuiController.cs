//using Microsoft.AspNetCore.Mvc;
//using Koi.Services.Interfaces;
//using Koi.Repositories.Entities;
//using System.Threading.Tasks;
//using System.Collections.Generic;

//namespace Koi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LichSuKyGuiController : ControllerBase
//    {
//        private readonly ILichSuKyGuiService _lichSuKyGuiService;

//        public LichSuKyGuiController(ILichSuKyGuiService lichSuKyGuiService)
//        {
//            _lichSuKyGuiService = lichSuKyGuiService;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<LichSuKyGui>> GetByIdAsync(int id)
//        {
//            var result = await _lichSuKyGuiService.GetByIdAsync(id);
//            if (result == null) return NotFound();
//            return Ok(result);
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<LichSuKyGui>>> GetAllAsync()
//        {
//            var result = await _lichSuKyGuiService.GetAllAsync();
//            return Ok(result);
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteAsync(int id)
//        {
//            var success = await _lichSuKyGuiService.DeleteAsync(id);
//            if (!success) return NotFound();
//            return NoContent();
//        }
//    }
//}
