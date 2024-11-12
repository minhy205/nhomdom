using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Entities;
using Koi.Repositories; // Điều chỉnh dựa trên namespace thực tế của IRepository

namespace Koi.Repositories.Interfaces
{
    public interface ICaKoiRepository
    {
        Task<CaKoi> GetByIdAsync(int caKoiID);  // Lấy CaKoi theo ID
        Task<IEnumerable<CaKoi>> GetAllAsync();  // Lấy tất cả CaKoi
        Task<CaKoi> AddAsync(CaKoi caKoi);  // Thêm một CaKoi mới
        Task<CaKoi> UpdateAsync(CaKoi caKoi);  // Cập nhật một CaKoi
        Task<bool> DeleteAsync(int caKoiID);  // Xóa CaKoi theo ID
    }
}
