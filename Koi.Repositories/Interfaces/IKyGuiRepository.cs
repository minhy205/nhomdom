using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi.Repositories.Interfaces
{
    public interface IKyGuiRepository
    {
        Task<KyGui> GetByIdAsync(int kyGuiID);  // Lấy KyGui theo ID
        Task<IEnumerable<KyGui>> GetByLichSuKyGuiIdAsync(int lichSuKyGuiID);  // Lấy KyGui theo ID của LichSuKyGui
        Task<KyGui> AddAsync(KyGui kyGui);  // Thêm một KyGui mới
        Task<KyGui> UpdateAsync(KyGui kyGui);  // Cập nhật một KyGui
        Task<bool> DeleteAsync(int kyGuiID);  // Xóa KyGui theo ID
    }
}
