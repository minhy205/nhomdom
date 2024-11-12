using Koi.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi.Repositories.Interfaces
{
    public interface ILichSuMuaHangRepository
    {
        Task<LichSuMuaHang> GetByIdAsync(int muaHangID);  // Lấy LichSuMuaHang theo ID
        Task<IEnumerable<LichSuMuaHang>> GetByKhachHangIdAsync(int maKhachHang);  // Lấy lịch sử mua hàng theo ID khách hàng
        Task<LichSuMuaHang> AddAsync(LichSuMuaHang lichSuMuaHang);  // Thêm một LichSuMuaHang mới
        Task<LichSuMuaHang> UpdateAsync(LichSuMuaHang lichSuMuaHang);  // Cập nhật một LichSuMuaHang
        Task<bool> DeleteAsync(int muaHangID);  // Xóa LichSuMuaHang theo ID
    }
}

