
namespace Koi.WebApplication.Models
{
    public class KoifarmModel
    {
        public int CaKoiId { get; set; } // Id ca Koi
        public string Breed { get; set; }  // Giống cá
        public string Origin { get; set; }  // Xuất xứ
        public string Gender { get; set; }  // Giới tính
        public int Age { get; set; }  // Tuổi
        public decimal Size { get; set; }  // Kích thước
        public string Personality { get; set; }  // Tính cách
        public decimal FoodPerDay { get; set; }  // Lượng thức ăn mỗi ngày
        public decimal ScreeningRate { get; set; }  // Tỉ lệ kiểm tra
        public decimal Price { get; set; }  // Giá
        public string Status { get; set; }  // Trạng thái (mới, đã bán, ...)
        public string Img { get; set; } // link hình ảnh cá Koi
    }
}
