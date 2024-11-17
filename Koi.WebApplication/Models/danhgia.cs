using System.ComponentModel.DataAnnotations;

namespace Koi.WebApplication.Models
{
    public class DanhGia
    {
        public int DanhGiaId { get; set; } // ID của đánh giá
        public string UserName { get; set; } // Tên người dùng

        [Required(ErrorMessage = "Số sao là bắt buộc.")]
        [Range(1, 5, ErrorMessage = "Số sao phải từ 1 đến 5.")]
        public int Diem { get; set; }

        [Required(ErrorMessage = "Bình luận là bắt buộc.")]
        [StringLength(500, ErrorMessage = "Bình luận không được vượt quá 500 ký tự.")]
        public string NoiDung { get; set; }
        public DateTime CreatedDate { get; set; } // Ngày tạo
    }
}
