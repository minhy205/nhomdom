using Koi.Models;  // Add this namespace at the top of your controller
// File: Koi/Models/SanPhamModel.cs
namespace Koi.Models
{
    public class SanPhamModel
    {
        public int SanPhamID { get; set; }
        public string TenSanPham { get; set; }
        public decimal? KichThuoc { get; set; }
        public decimal? Gia { get; set; }
        public string NguonGoc { get; set; }
        public string Giong { get; set; }
        public string GioiTinh { get; set; }
        public byte[] Anh { get; set; }
    }
}
