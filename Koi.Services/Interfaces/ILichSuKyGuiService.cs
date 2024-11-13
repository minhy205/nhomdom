using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;

namespace Koi.Services.Interfaces
{
    public interface ILichSuKyGuiService
    {
        Task<LichSuKyGui> GetByIdAsync(int lichSuKyGuiID);  // Get LichSuKyGui by ID
        Task<IEnumerable<LichSuKyGui>> GetAllAsync();  // Get all LichSuKyGui
        Task<LichSuKyGui> AddAsync(LichSuKyGui lichSuKyGui);  // Add a new LichSuKyGui
        Task<LichSuKyGui> UpdateAsync(LichSuKyGui lichSuKyGui);  // Update an existing LichSuKyGui
        Task<bool> DeleteAsync(int lichSuKyGuiID);  // Delete LichSuKyGui by ID
    }
}