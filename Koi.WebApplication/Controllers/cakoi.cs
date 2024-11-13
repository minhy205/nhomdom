//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Koi.WebApplication.Controllers
//{
//    public class cakoi : Controller
//    {
//        // GET: /<controller>/
//        public IActionResult Index()
//        {
//            return View();
//        }
//        public IActionResult cacloaicakoi()
//        {
//            return View();
//        }
//    }
//}


using Koi.Repositories.Entities;
using Koi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Koi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CaKoiController : ControllerBase
    {
        private readonly ICaKoiService _caKoiService;

        public CaKoiController(ICaKoiService caKoiService)
        {
            _caKoiService = caKoiService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var caKoi = await _caKoiService.GetByIdAsync(id);
            if (caKoi == null)
                return NotFound();

            return Ok(caKoi);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var caKois = await _caKoiService.GetAllAsync();
            return Ok(caKois);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CaKoi caKoi)
        {
            var createdCaKoi = await _caKoiService.AddAsync(caKoi);
            return CreatedAtAction(nameof(GetById), new { id = createdCaKoi.CaKoiId }, createdCaKoi);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CaKoi caKoi)
        {
            var updatedCaKoi = await _caKoiService.UpdateAsync(caKoi);
            if (updatedCaKoi == null)
                return NotFound();

            return Ok(updatedCaKoi);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _caKoiService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}


