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
    public interface IDanhGiaRepository
    {
        Task<DanhGia> GetByIdAsync(int danhGiaID);  // Lấy DanhGia theo ID
        Task<IEnumerable<DanhGia>> GetByCaKoiIdAsync(int caKoiID);  // Lấy danh sách đánh giá cho một CaKoi
        Task<DanhGia> AddAsync(DanhGia danhGia, DanhGium danhgia);  // Thêm một DanhGia mới
        Task<DanhGia> UpdateAsync(DanhGia danhGia);  // Cập nhật một DanhGia
        Task<bool> DeleteAsync(int danhGiaID);  // Xóa DanhGia theo ID
        Task<DanhGia> AddAsync(DanhGia danhGia);
    }
}
