namespace Koi.WebApplication.Models
{
    public class licsumuahang
    {
        public int ProductId { get; set; }  // ID sản phẩm
        public string ProductName { get; set; }  // Tên sản phẩm
        public decimal Price { get; set; }  // Giá sản phẩm
        public int Quantity { get; set; }  // Số lượng sản phẩm
        public string Status { get; set; }  // Trạng thái sản phẩm (đã mua, đang chờ,...)
        public string ImageUrl { get; set; }  // Địa chỉ URL của hình ảnh sản phẩm

    }
}
