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

        public Task<LichSuMuaHang> GetByIdAsync(int muaHangID) => _lichSuMuaHangRepository.GetByIdAsync(muaHangID);
        public Task<IEnumerable<LichSuMuaHang>> GetByKhachHangIdAsync(int maKhachHang) => _lichSuMuaHangRepository.GetByKhachHangIdAsync(maKhachHang);
        public Task<LichSuMuaHang> AddAsync(LichSuMuaHang lichSuMuaHang) => _lichSuMuaHangRepository.AddAsync(lichSuMuaHang);
        public Task<LichSuMuaHang> UpdateAsync(LichSuMuaHang lichSuMuaHang) => _lichSuMuaHangRepository.UpdateAsync(lichSuMuaHang);
        public Task<bool> DeleteAsync(int muaHangID) => _lichSuMuaHangRepository.DeleteAsync(muaHangID);
    }
}