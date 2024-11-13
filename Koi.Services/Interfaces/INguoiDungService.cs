using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;

namespace Koi.Services.Interfaces
{
    public interface INguoiDungService
    {
        Task<NguoiDung> GetByIdAsync(int khachHangID);  // Get NguoiDung by ID
        Task<IEnumerable<NguoiDung>> GetByUserIdAsync(int userID);  // Get NguoiDung by user ID
        Task<NguoiDung> AddAsync(NguoiDung nguoiDung);  // Add a new NguoiDung
        Task<NguoiDung> UpdateAsync(NguoiDung nguoiDung);  // Update an existing NguoiDung
        Task<bool> DeleteAsync(int khachHangID);  // Delete NguoiDung by ID
    }
}