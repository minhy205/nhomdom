using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;

namespace Koi.Repositories.Interfaces
{
    public interface IGioHangCuaToiRepository
    {
        Task<GioHangCuaToi> GetByIdAsync(int gioHangID);  // Lấy GioHangCuaToi theo ID
        Task<IEnumerable<GioHangCuaToi>> GetByCaKoiIdAsync(int caKoiID);  // Lấy các mục trong giỏ hàng theo CaKoi
        Task<GioHangCuaToi> AddAsync(GioHangCuaToi gioHangCuaToi);  // Thêm một mục vào giỏ hàng
        Task<GioHangCuaToi> UpdateAsync(GioHangCuaToi gioHangCuaToi);  // Cập nhật một mục trong giỏ hàng
        Task<bool> DeleteAsync(int gioHangID);  // Xóa một mục khỏi giỏ hàng theo ID
        Task<IEnumerable<GioHangCuaToi>> GetAllAsync();  // Lấy tất cả các mục trong giỏ hàng
    }
}
