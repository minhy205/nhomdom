using Koi.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi.Repositories.Interfaces
{
    public interface INguoiDungRepository
    {
        Task<NguoiDung> GetByIdAsync(int khachHangID);  // Lấy NguoiDung theo ID
        Task<IEnumerable<NguoiDung>> GetByUserIdAsync(int userID);  // Lấy NguoiDung theo ID người dùng
        Task<NguoiDung> AddAsync(NguoiDung nguoiDung);  // Thêm một NguoiDung mới
        Task<NguoiDung> UpdateAsync(NguoiDung nguoiDung);  // Cập nhật một NguoiDung
        Task<bool> DeleteAsync(int khachHangID);  // Xóa NguoiDung theo ID
    }
}

