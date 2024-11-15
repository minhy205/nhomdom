using Microsoft.AspNetCore.Mvc;
using Koi.Services.Interfaces;
using Koi.Repositories.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using Koi.Repositories.Interfaces;

namespace Koi.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly ISanPhamServices _sanPhamServices;

        public SanPhamController(ISanPhamServices sanPhamServices)
        {
            _sanPhamServices = sanPhamServices;
        }

        // GET: SanPham
        public async Task<IActionResult> Index()
        {
            var sanPhams = await _sanPhamServices.GetAllAsync(); // Lấy tất cả sản phẩm
            return View(sanPhams); // Trả về view với danh sách sản phẩm
        }

        // GET: SanPham/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var sanPham = await _sanPhamServices.GetByIdAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            return View(sanPham); // Trả về view chi tiết sản phẩm
        }

        // GET: SanPham/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var sanPham = await _sanPhamServices.GetByIdAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            return View(sanPham); // Trả về view xóa sản phẩm
        }

        // POST: SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _sanPhamServices.DeleteAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index)); // Sau khi xóa, chuyển hướng về danh sách sản phẩm
        }
    }
}
