using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Koi.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Koi.WebApplication.Controllers
{
    public class KoifarmController : Controller
    {
        // Đây là danh sách giả lập lưu trữ các loại cá Koi
        private static List<KoifarmModel> koiList = new List<KoifarmModel>
        {
            new KoifarmModel
            {
                CaKoiId         = 1,
                Breed           = "Kohaku",
                Origin          = "Nhật Bản",
                Gender          = "Cái",
                Age             = 3,
                Size            = 45.5m,
                Personality     = "Hiền hòa",
                FoodPerDay      = 200,
                ScreeningRate   = 98.5m,
                Price           = 2000000,
                Status          = "Mới",
                Img             = "https://cakoibienhoa.com/public/userfiles/products/ca-koi-kohaku.jpg"
            },
            new KoifarmModel
            {
                CaKoiId         = 2,
                Breed           = "Tancho",
                Origin          = "Nhật Bản",
                Gender          = "Đực",
                Age             = 2,
                Size            = 40.0m,
                Personality     = "Năng động",
                FoodPerDay      = 180,
                ScreeningRate   = 95.0m,
                Price           = 1800000,
                Status          = "Mới",
                Img             = "https://cakoibienhoa.com/public/userfiles/products/ca-koi-tancho-thumb.jpg"
            }
        };

        // Action để hiển thị danh sách cá Koi
        public IActionResult Index()
        {
            return View(koiList);
        }

        // Action để hiển thị form thêm cá Koi mới
        public IActionResult Create()
        {
            return View();
        }

        // Action xử lý việc thêm cá Koi mới vào danh sách
        [HttpPost]
        public IActionResult Create(KoifarmModel newKoi)
        {
            if (ModelState.IsValid)
            {
                // Tạo ID mới cho cá Koi
                newKoi.CaKoiId = koiList.Count + 1;

                // Thêm cá Koi vào danh sách
                koiList.Add(newKoi);

                // Sau khi thêm thành công, chuyển hướng về trang danh sách cá Koi (Index)
                return RedirectToAction("Index");
            }
            return View(newKoi);
        }

        // Action để hiển thị thông tin chi tiết của một cá Koi
        public IActionResult Details(int id)
        {
            var koi = koiList.FirstOrDefault(k => k.CaKoiId == id);
            if (koi == null)
            {
                return NotFound();
            }
            return View(koi);
        }

        // Action để hiển thị form chỉnh sửa thông tin cá Koi
        public IActionResult Edit(int id)
        {
            var koi = koiList.FirstOrDefault(k => k.CaKoiId == id);
            if (koi == null)
            {
                return NotFound();
            }
            return View(koi);
        }

        // Action xử lý việc chỉnh sửa cá Koi
        [HttpPost]
        public IActionResult Edit(KoifarmModel editedKoi)
        {
            if (ModelState.IsValid)
            {
                var koiToEdit = koiList.FirstOrDefault(k => k.CaKoiId == editedKoi.CaKoiId);
                if (koiToEdit == null)
                {
                    return NotFound();
                }

                // Cập nhật thông tin cá Koi
                koiToEdit.Breed = editedKoi.Breed;
                koiToEdit.Origin = editedKoi.Origin;
                koiToEdit.Gender = editedKoi.Gender;
                koiToEdit.Age = editedKoi.Age;
                koiToEdit.Size = editedKoi.Size;
                koiToEdit.Personality = editedKoi.Personality;
                koiToEdit.FoodPerDay = editedKoi.FoodPerDay;
                koiToEdit.ScreeningRate = editedKoi.ScreeningRate;
                koiToEdit.Price = editedKoi.Price;
                koiToEdit.Status = editedKoi.Status;
                koiToEdit.Img = editedKoi.Img;

                // Sau khi chỉnh sửa, chuyển hướng về trang danh sách cá Koi (Index)
                return RedirectToAction("Index");
            }
            return View(editedKoi);
        }

        // Action xử lý việc xóa cá Koi khỏi danh sách
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var koiToDelete = koiList.FirstOrDefault(k => k.CaKoiId == id);
            if (koiToDelete != null)
            {
                koiList.Remove(koiToDelete);
            }
            // Sau khi xóa, chuyển hướng về trang danh sách cá Koi (Index)
            return RedirectToAction("Index");
        }
        public IActionResult CacLoaiCaKoi()
        {
            return View(koiList);
        }
        public IActionResult KoiKohaku()
        {
            return View(koiList);
        }
        public IActionResult KoiOgon()
        {
            return View(koiList);
        }
        public IActionResult KoiTancho()
        {
            return View(koiList);
        }
        public IActionResult KoiAsagi()
        {
            return View(koiList);
        }
        public IActionResult KoiShowa()
        {
            return View(koiList);
        }
    }
}
