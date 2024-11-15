using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;

namespace Koi.Services.Interfaces
{
    public interface IDanhGiaService
    {
        Task<DanhGia> GetByIdAsync(int danhGiaID);
        Task<IEnumerable<DanhGia>> GetByCaKoiIdAsync(int caKoiID);
        Task<IEnumerable<DanhGia>> GetAllAsync();  // Phương thức này cần có trong giao diện
        Task<DanhGia> AddAsync(DanhGia danhGia);
        Task<DanhGia> UpdateAsync(DanhGia danhGia);
        Task<bool> DeleteAsync(int danhGiaID);
    }

}