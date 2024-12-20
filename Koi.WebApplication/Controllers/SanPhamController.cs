﻿using Microsoft.AspNetCore.Mvc;
using Koi.Repositories.Entities;
using System.Threading.Tasks;
using Koi.Repositories.Interfaces;
using Koi.WebApplication.Models;

namespace Koi.Controllers
{
    public class SanPhamController : Controller
    {

        private readonly IRepository<SanPham> _sanPhamRepository;

        // Constructor injection for repository
        public SanPhamController(IRepository<SanPham> sanPhamRepository)
        {
            _sanPhamRepository = sanPhamRepository;
        }

        // GET: SanPham
        public async Task<IActionResult> Index()
        {
            var sanPhams = await _sanPhamRepository.GetAllAsync();
            return View(sanPhams);
        }

        // GET: SanPham/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var sanPham = await _sanPhamRepository.GetByIdAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            return View(sanPham); // Trả về view chi tiết sản phẩm
        }

        // GET: SanPham/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var sanPham = await _sanPhamRepository.GetByIdAsync(id);
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
            await _sanPhamRepository.DeleteAsync(id); // Xóa sản phẩm qua repository
            return RedirectToAction(nameof(Index)); // Sau khi xóa, chuyển hướng về danh sách sản phẩm
        }
        // GET: SanPham/KoiDangBan
        [HttpGet("SanPham/KoiDangBan")]
        public async Task<IActionResult> KoiDangBan()
        {
            // Logic to retrieve Koi fish that are currently for sale
            var koiDangBan = await _sanPhamRepository.GetAllAsync(); // Adjust this query to filter only koi for sale if needed
            return View(koiDangBan); // Trả về view cho sản phẩm đang bán
        }
        // GET: SanPham/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SanPham/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SanPhamModel sanPham)
        {
            if (ModelState.IsValid)
            {
                // Lưu sản phẩm vào cơ sở dữ liệu
                // VD: _context.SanPhams.Add(sanPham);
                // _context.SaveChanges();

                return RedirectToAction("Index"); // Chuyển hướng về danh sách sản phẩm
            }

            return View(sanPham);
        }

    }
}
