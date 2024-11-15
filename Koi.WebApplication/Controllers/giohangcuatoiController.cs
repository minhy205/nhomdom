using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;
using Koi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Koi.Controllers
{
    public class GioHangCuaToiController : Controller
    {
        private readonly IGioHangCuaToiService _gioHangCuaToiService;

        public GioHangCuaToiController(IGioHangCuaToiService gioHangCuaToiService)
        {
            _gioHangCuaToiService = gioHangCuaToiService;
        }

        // GET: GioHangCuaToi
        public async Task<IActionResult> Index()
        {
            var gioHangs = await _gioHangCuaToiService.GetAllAsync();
            return View(gioHangs); // Trả về view với danh sách giỏ hàng
        }

        // GET: GioHangCuaToi/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var gioHang = await _gioHangCuaToiService.GetByIdAsync(id);
            if (gioHang == null)
            {
                return NotFound();
            }
            return View(gioHang); // Trả về view chi tiết giỏ hàng
        }

        // GET: GioHangCuaToi/Create
        public IActionResult Create()
        {
            return View(); // Trả về view để tạo mới giỏ hàng
        }

        // POST: GioHangCuaToi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GioHangCuaToi gioHangCuaToi)
        {
            if (ModelState.IsValid)
            {
                var newGioHang = await _gioHangCuaToiService.AddAsync(gioHangCuaToi);
                return RedirectToAction(nameof(Index)); // Sau khi tạo mới, chuyển hướng về danh sách giỏ hàng
            }
            return View(gioHangCuaToi); // Nếu dữ liệu không hợp lệ, trả về view hiện tại
        }

        // GET: GioHangCuaToi/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var gioHang = await _gioHangCuaToiService.GetByIdAsync(id);
            if (gioHang == null)
            {
                return NotFound();
            }
            return View(gioHang); // Trả về view chỉnh sửa giỏ hàng
        }

        // POST: GioHangCuaToi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GioHangCuaToi gioHangCuaToi)
        {
            if (id != gioHangCuaToi.GioHangId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var updatedGioHang = await _gioHangCuaToiService.UpdateAsync(gioHangCuaToi);
                if (updatedGioHang == null)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index)); // Sau khi chỉnh sửa thành công, chuyển hướng về danh sách
            }
            return View(gioHangCuaToi);
        }

        // GET: GioHangCuaToi/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var gioHang = await _gioHangCuaToiService.GetByIdAsync(id);
            if (gioHang == null)
            {
                return NotFound();
            }
            return View(gioHang); // Trả về view xóa giỏ hàng
        }

        // POST: GioHangCuaToi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _gioHangCuaToiService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index)); // Sau khi xóa thành công, chuyển hướng về danh sách
        }
    }
}
