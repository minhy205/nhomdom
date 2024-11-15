using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;

namespace Koi.Services.Interfaces
{
    public interface IGioHangCuaToiService
    {
        Task<GioHangCuaToi> GetByIdAsync(int gioHangID);  // Lấy GioHangCuaToi theo ID
        Task<IEnumerable<GioHangCuaToi>> GetByCaKoiIdAsync(int caKoiID);  // Lấy tất cả các sản phẩm trong giỏ hàng của một CaKoi
        Task<IEnumerable<GioHangCuaToi>> GetAllAsync();  // Lấy tất cả các sản phẩm trong giỏ hàng
        Task<GioHangCuaToi> AddAsync(GioHangCuaToi gioHangCuaToi);  // Thêm một sản phẩm vào giỏ hàng
        Task<GioHangCuaToi> UpdateAsync(GioHangCuaToi gioHangCuaToi);  // Cập nhật một sản phẩm trong giỏ hàng
        Task<bool> DeleteAsync(int gioHangID);  // Xóa một sản phẩm khỏi giỏ hàng theo ID
    }
}
