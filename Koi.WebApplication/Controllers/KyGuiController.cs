using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace YourNamespace.Controllers
{
    public class KyGuiController : Controller
    {
        // Lấy danh sách sản phẩm ký gửi từ session
        private List<ConsignmentItem> GetConsignmentFromSession()
        {
            var consignment = HttpContext.Session.GetString("Consignment");
            return string.IsNullOrEmpty(consignment) ? new List<ConsignmentItem>() : JsonConvert.DeserializeObject<List<ConsignmentItem>>(consignment);
        }

        // Lưu danh sách sản phẩm ký gửi vào session
        private void SaveConsignmentToSession(List<ConsignmentItem> consignment)
        {
            HttpContext.Session.SetString("Consignment", JsonConvert.SerializeObject(consignment));
        }

        // Hiển thị trang Ký gửi của tôi
        public IActionResult Index()
        {
            var consignment = GetConsignmentFromSession();
            return View(consignment);
        }

        // Thêm sản phẩm vào mục ký gửi
        [HttpPost]
        public IActionResult AddToConsignment(string productName, string productCode, string origin, string gender, string size, double price, int quantity)
        {
            if (string.IsNullOrEmpty(productName) || price <= 0 || quantity <= 0)
            {
                return BadRequest("Thông tin không hợp lệ");
            }

            var consignment = GetConsignmentFromSession();

            var newItem = new ConsignmentItem
            {
                ProductName = productName,
                ProductCode = productCode,
                Origin = origin,
                Gender = gender,
                Size = size,
                Price = price,
                Quantity = quantity,
                ImageUrl = "path_to_image.jpg" // Đặt đường dẫn hình ảnh sản phẩm nếu có
            };

            consignment.Add(newItem);
            SaveConsignmentToSession(consignment);

            return RedirectToAction("Index");
        }

        // Xóa sản phẩm khỏi mục ký gửi
        [HttpPost]
        public IActionResult RemoveFromConsignment(string productName)
        {
            var consignment = GetConsignmentFromSession();
            var updatedConsignment = consignment.FindAll(item => item.ProductName != productName);
            SaveConsignmentToSession(updatedConsignment);

            return RedirectToAction("Index");
        }

        // Cập nhật số lượng sản phẩm trong mục ký gửi
        [HttpPost]
        public IActionResult UpdateConsignmentQuantity(string productName, int quantity)
        {
            var consignment = GetConsignmentFromSession();
            var item = consignment.Find(i => i.ProductName == productName);
            if (item != null)
            {
                item.Quantity = quantity;
                SaveConsignmentToSession(consignment);
            }

            return RedirectToAction("Index");
        }
    }

    // Lớp đại diện cho sản phẩm ký gửi
    public class ConsignmentItem
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string Origin { get; set; }
        public string Gender { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
    }
}
