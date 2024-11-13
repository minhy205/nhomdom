using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;

namespace Koi.Services.Interfaces
{
    public interface IGioHangCuaToiService
    {
        Task<GioHangCuaToi> GetByIdAsync(int gioHangID);  // Get GioHangCuaToi by ID
        Task<IEnumerable<GioHangCuaToi>> GetByCaKoiIdAsync(int caKoiID);  // Get all items in the cart for a CaKoi
        Task<GioHangCuaToi> AddAsync(GioHangCuaToi gioHangCuaToi);  // Add a new item to the cart
        Task<GioHangCuaToi> UpdateAsync(GioHangCuaToi gioHangCuaToi);  // Update an existing item in the cart
        Task<bool> DeleteAsync(int gioHangID);  // Delete an item from the cart by ID
    }
}