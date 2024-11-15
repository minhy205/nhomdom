using Microsoft.AspNetCore.Mvc;
using Koi.Services.Interfaces;
using Koi.Repositories.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Koi.Controllers
{
    public class LichSuMuaHangController : Controller
    {
        private readonly ILichSuMuaHangService _lichSuMuaHangService;

        public LichSuMuaHangController(ILichSuMuaHangService lichSuMuaHangService)
        {
            _lichSuMuaHangService = lichSuMuaHangService;
        }

        // GET: LichSuMuaHang
        public async Task<IActionResult> Index()
        {
            var lichSuMuaHangs = await _lichSuMuaHangService.GetAllAsync(); // Lấy tất cả lịch sử mua hàng
            return View(lichSuMuaHangs); // Trả về view với danh sách lịch sử
        }

        // GET: LichSuMuaHang/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var lichSuMuaHang = await _lichSuMuaHangService.GetByIdAsync(id);
            if (lichSuMuaHang == null)
            {
                return NotFound();
            }
            return View(lichSuMuaHang); // Trả về view chi tiết lịch sử mua hàng
        }

        // GET: LichSuMuaHang/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var lichSuMuaHang = await _lichSuMuaHangService.GetByIdAsync(id);
            if (lichSuMuaHang == null)
            {
                return NotFound();
            }
            return View(lichSuMuaHang); // Trả về view xóa lịch sử mua hàng
        }

        // POST: LichSuMuaHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _lichSuMuaHangService.DeleteAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index)); // Sau khi xóa, chuyển hướng về danh sách lịch sử
        }
    }
}
