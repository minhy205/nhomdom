using Koi.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi.Repositories.Interfaces
{
    public interface ILichSuKyGuiRepository
    {
        Task<LichSuKyGui> GetByIdAsync(int lichSuKyGuiID);  // Lấy LichSuKyGui theo ID
        Task<IEnumerable<LichSuKyGui>> GetAllAsync();  // Lấy tất cả LichSuKyGui
        Task<LichSuKyGui> AddAsync(LichSuKyGui lichSuKyGui);  // Thêm một LichSuKyGui mới
        Task<LichSuKyGui> UpdateAsync(LichSuKyGui lichSuKyGui);  // Cập nhật một LichSuKyGui
        Task<bool> DeleteAsync(int lichSuKyGuiID);  // Xóa LichSuKyGui theo ID
    }
}
