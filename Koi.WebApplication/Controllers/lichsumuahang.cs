using Koi.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

public class LichSuMuaHangController : Controller
{
    // Đây là danh sách giả lập lưu trữ lịch sử mua hàng (trong thực tế có thể lấy từ cơ sở dữ liệu)
    private static List<licsumuahang> purchaseHistoryList = new List<licsumuahang>
    {
        new licsumuahang
        {
            ProductId = 1,
            ProductName = "Cá Koi Nhật Bản",
            Price = 1000000,
            Quantity = 2,
            Status = "Đã mua",
            ImageUrl = "https://example.com/cacoi1.jpg"
        },
        new licsumuahang
        {
            ProductId = 2,
            ProductName = "Cá Koi Ấn Độ",
            Price = 500000,
            Quantity = 1,
            Status = "Đã mua",
            ImageUrl = "https://example.com/cacoi2.jpg"
        }
    };

    // Action để hiển thị Lịch sử mua hàng
    public IActionResult Index()
    {
        // Đảm bảo purchaseHistoryList được khởi tạo đúng cách
        if (purchaseHistoryList == null)
        {
            purchaseHistoryList = new List<licsumuahang>(); // Khởi tạo lại nếu null
        }

        return View(purchaseHistoryList);
    }
    public IActionResult AddProduct()
    {
        return View();
    }
    // Action xử lý việc thêm sản phẩm vào danh sách
    [HttpPost]
    public IActionResult AddProduct(string productName, decimal price, int quantity, string status, string imageUrl)
    {
        // Tạo đối tượng PurchaseHistory mới từ thông tin form
        var newProduct = new licsumuahang
        {
            ProductId = purchaseHistoryList.Count + 1, // Tạo ID tự động
            ProductName = productName,
            Price = price,
            Quantity = quantity,
            Status = status,
            ImageUrl = imageUrl
        };

        // Thêm sản phẩm mới vào danh sách
        purchaseHistoryList.Add(newProduct);

        // Sau khi thêm thành công, chuyển hướng về trang Lịch sử mua hàng (Index)
        return RedirectToAction("Index");
    }

    // Action xử lý việc xóa sản phẩm
    [HttpPost]
    public IActionResult RemoveProduct(int productId)
    {
        // Tìm sản phẩm trong danh sách bằng ProductId
        var productToRemove = purchaseHistoryList.FirstOrDefault(p => p.ProductId == productId);

        if (productToRemove != null)
        {
            // Xóa sản phẩm khỏi danh sách
            purchaseHistoryList.Remove(productToRemove);
        }

        // Sau khi xóa sản phẩm, chuyển hướng về trang Lịch sử mua hàng (Index)
        return RedirectToAction("Index");
    }
    public IActionResult Index1()
    {
        // Giả sử bạn có danh sách PurchaseHistory
        var purchaseHistoryList = new List<licsumuahang>
    {
        new licsumuahang { ProductName = "Cá Koi Kohaku", Price = 1000000, Quantity = 2, Status = "Đã mua", ImageUrl = "https://example.com/cacoi1.jpg" },
        new licsumuahang { ProductName = "Cá Koi Karashi", Price = 500000, Quantity = 1, Status = "Đã mua", ImageUrl = "https://example.com/cacoi2.jpg" }
    };

        return View(purchaseHistoryList);
    }
}
