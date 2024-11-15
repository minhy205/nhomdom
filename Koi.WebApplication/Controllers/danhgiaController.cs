using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;
using Koi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Koi.Controllers
{
    public class DanhGiaController : Controller
    {
        private readonly IDanhGiaService _danhGiaService;

        public DanhGiaController(IDanhGiaService danhGiaService)
        {
            _danhGiaService = danhGiaService;
        }

        // GET: DanhGia
        public async Task<IActionResult> Index()
        {
            var danhGias = await _danhGiaService.GetAllAsync();
            return View(danhGias); // Trả về view với danh sách tất cả các đánh giá
        }

        // GET: DanhGia/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var danhGia = await _danhGiaService.GetByIdAsync(id);
            if (danhGia == null)
            {
                return NotFound();
            }
            return View(danhGia); // Trả về view chi tiết của đánh giá
        }

        // GET: DanhGia/Create
        public IActionResult Create()
        {
            return View(); // Trả về view để tạo mới đánh giá
        }

        // POST: DanhGia/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DanhGia danhGia)
        {
            if (ModelState.IsValid)
            {
                var newDanhGia = await _danhGiaService.AddAsync(danhGia);
                return RedirectToAction(nameof(Index)); // Chuyển hướng về danh sách sau khi thêm mới
            }
            return View(danhGia); // Nếu dữ liệu không hợp lệ, trả về view hiện tại
        }

        // GET: DanhGia/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var danhGia = await _danhGiaService.GetByIdAsync(id);
            if (danhGia == null)
            {
                return NotFound();
            }
            return View(danhGia); // Trả về view chỉnh sửa
        }

        // POST: DanhGia/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DanhGia danhGia)
        {
            if (id != danhGia.DanhGiaId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var updatedDanhGia = await _danhGiaService.UpdateAsync(danhGia);
                if (updatedDanhGia == null)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index)); // Sau khi chỉnh sửa thành công, chuyển hướng về danh sách
            }
            return View(danhGia);
        }

        // GET: DanhGia/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var danhGia = await _danhGiaService.GetByIdAsync(id);
            if (danhGia == null)
            {
                return NotFound();
            }
            return View(danhGia); // Trả về view xóa
        }

        // POST: DanhGia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _danhGiaService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index)); // Sau khi xóa thành công, chuyển hướng về danh sách
        }
    }
}
