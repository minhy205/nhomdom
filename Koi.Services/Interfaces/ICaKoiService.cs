using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;

namespace Koi.Services.Interfaces
{
    public interface ICaKoiService
    {
        Task<CaKoi> GetByIdAsync(int caKoiID);  // Get CaKoi by ID
        Task<IEnumerable<CaKoi>> GetAllAsync();  // Get all CaKoi
        Task<CaKoi> AddAsync(CaKoi caKoi);       // Add a new CaKoi
        Task<CaKoi> UpdateAsync(CaKoi caKoi);    // Update an existing CaKoi
        Task<bool> DeleteAsync(int caKoiID);      // Delete CaKoi by ID
    }
}