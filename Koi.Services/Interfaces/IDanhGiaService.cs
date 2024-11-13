using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;

namespace Koi.Services.Interfaces
{
    public interface IDanhGiaService
    {
        Task<DanhGia> GetByIdAsync(int danhGiaID);  // Get DanhGia by ID
        Task<IEnumerable<DanhGia>> GetByCaKoiIdAsync(int caKoiID);  // Get all DanhGias for a CaKoi
        Task<DanhGia> AddAsync(DanhGia danhGia);  // Add a new DanhGia
        Task<DanhGia> UpdateAsync(DanhGia danhGia);  // Update an existing DanhGia
        Task<bool> DeleteAsync(int danhGiaID);  // Delete DanhGia by ID
    }
}