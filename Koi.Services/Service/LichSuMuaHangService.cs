using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;
using Koi.Repositories.Interfaces;
using Koi.Services.Interfaces;

namespace Koi.Services
{
    public class LichSuMuaHangService : ILichSuMuaHangService
    {
        private readonly ILichSuMuaHangRepository _lichSuMuaHangRepository;

        public LichSuMuaHangService(ILichSuMuaHangRepository lichSuMuaHangRepository)
        {
            _lichSuMuaHangRepository = lichSuMuaHangRepository;
        }

        public async Task<LichSuMuaHang> GetByIdAsync(int muaHangID)
        {
            return await _lichSuMuaHangRepository.GetByIdAsync(muaHangID);
        }

        public async Task<IEnumerable<LichSuMuaHang>> GetByKhachHangIdAsync(int maKhachHang)
        {
            return await _lichSuMuaHangRepository.GetByKhachHangIdAsync(maKhachHang);
        }

        public async Task<IEnumerable<LichSuMuaHang>> GetAllAsync()
        {
            return await _lichSuMuaHangRepository.GetAllAsync();  // Sử dụng phương thức từ repository
        }

        public async Task<LichSuMuaHang> AddAsync(LichSuMuaHang lichSuMuaHang)
        {
            return await _lichSuMuaHangRepository.AddAsync(lichSuMuaHang);
        }

        public async Task<LichSuMuaHang> UpdateAsync(LichSuMuaHang lichSuMuaHang)
        {
            return await _lichSuMuaHangRepository.UpdateAsync(lichSuMuaHang);
        }

        public async Task<bool> DeleteAsync(int muaHangID)
        {
            return await _lichSuMuaHangRepository.DeleteAsync(muaHangID);
        }
    }
}
