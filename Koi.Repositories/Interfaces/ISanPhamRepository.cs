using Koi.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi.Repositories.Interfaces
{
    public interface ISanPhamRepository
    {
        Task<SanPham> GetByIdAsync(int sanPhamID);  // Lấy SanPham theo ID
        Task<IEnumerable<SanPham>> GetAllAsync();  // Lấy tất cả các SanPham
        Task<SanPham> AddAsync(SanPham sanPham);  // Thêm một SanPham mới
        Task<SanPham> UpdateAsync(SanPham sanPham);  // Cập nhật một SanPham
        Task<bool> DeleteAsync(int sanPhamID);  // Xóa SanPham theo ID
    }
}
