using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;

namespace Koi.Repositories.Interfaces
{
    public interface IDanhGiaRepository
    {
        Task<IEnumerable<DanhGia>> GetAllAsync();
        Task<DanhGia> GetByIdAsync(int danhGiaId);
        Task<IEnumerable<DanhGia>> GetByCaKoiIdAsync(int caKoiId);
        Task<DanhGia> AddAsync(DanhGia danhGia);
        Task<DanhGia> UpdateAsync(DanhGia danhGia);
        Task<bool> DeleteAsync(int danhGiaId);
    }
}
