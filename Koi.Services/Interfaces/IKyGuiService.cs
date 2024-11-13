using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;

namespace Koi.Services.Interfaces
{
    public interface IKyGuiService
    {
        Task<KyGui> GetByIdAsync(int kyGuiID);  // Get KyGui by ID
        Task<IEnumerable<KyGui>> GetByLichSuKyGuiIdAsync(int lichSuKyGuiID);  // Get KyGui by LichSuKyGui ID
        Task<KyGui> AddAsync(KyGui kyGui);  // Add a new KyGui
        Task<KyGui> UpdateAsync(KyGui kyGui);  // Update an existing KyGui
        Task<bool> DeleteAsync(int kyGuiID);  // Delete KyGui by ID
    }
}