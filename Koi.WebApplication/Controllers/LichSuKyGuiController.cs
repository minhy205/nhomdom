using Microsoft.AspNetCore.Mvc;
using Koi.Services.Interfaces;
using Koi.Repositories.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Koi.Controllers
{
    public class LichSuKyGuiController : Controller
    {
        private readonly ILichSuKyGuiService _lichSuKyGuiService;

        public LichSuKyGuiController(ILichSuKyGuiService lichSuKyGuiService)
        {
            _lichSuKyGuiService = lichSuKyGuiService;
        }

        // GET: LichSuKyGui
        public async Task<IActionResult> Index()
        {
            var lichSuKyGuis = await _lichSuKyGuiService.GetAllAsync(); // Lấy tất cả lịch sử ký gửi
            return View(lichSuKyGuis); // Trả về view với danh sách lịch sử
        }

        // GET: LichSuKyGui/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var lichSuKyGui = await _lichSuKyGuiService.GetByIdAsync(id);
            if (lichSuKyGui == null)
            {
                return NotFound();
            }
            return View(lichSuKyGui); // Trả về view chi tiết lịch sử ký gửi
        }

        // GET: LichSuKyGui/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var lichSuKyGui = await _lichSuKyGuiService.GetByIdAsync(id);
            if (lichSuKyGui == null)
            {
                return NotFound();
            }
            return View(lichSuKyGui); // Trả về view xóa lịch sử ký gửi
        }

        // POST: LichSuKyGui/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _lichSuKyGuiService.DeleteAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index)); // Sau khi xóa, chuyển hướng về danh sách lịch sử
        }
    }
}