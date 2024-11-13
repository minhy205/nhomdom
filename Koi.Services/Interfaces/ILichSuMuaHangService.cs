using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;

namespace Koi.Services.Interfaces
{
    public interface ILichSuMuaHangService
    {
        Task<LichSuMuaHang> GetByIdAsync(int muaHangID);  // Get LichSuMuaHang by ID
        Task<IEnumerable<LichSuMuaHang>> GetByKhachHangIdAsync(int maKhachHang);  // Get purchase history by customer ID
        Task<LichSuMuaHang> AddAsync(LichSuMuaHang lichSuMuaHang);  // Add a new LichSuMuaHang
        Task<LichSuMuaHang> UpdateAsync(LichSuMuaHang lichSuMuaHang);  // Update an existing LichSuMuaHang
        Task<bool> DeleteAsync(int muaHangID);  // Delete LichSuMuaHang by ID
    }
}