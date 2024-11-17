using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;

namespace Koi.Services.Interfaces
{
    public interface IKyGuiService
    {
        Task<KyGui> GetByIdAsync(int kyGuiID);
        Task<IEnumerable<KyGui>> GetAllAsync();
        Task<IEnumerable<KyGui>> GetByLichSuKyGuiIdAsync(int lichSuKyGuiID);
        Task<KyGui> AddAsync(KyGui kyGui);
        Task<KyGui> UpdateAsync(KyGui kyGui);
        Task<bool> DeleteAsync(int kyGuiID);
    }
}