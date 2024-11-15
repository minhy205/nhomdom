using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;
using Koi.Repositories.Interfaces;
using Koi.Services.Interfaces;

namespace Koi.Services
{
    public class GioHangCuaToiService : IGioHangCuaToiService
    {
        private readonly IGioHangCuaToiRepository _gioHangCuaToiRepository;

        public GioHangCuaToiService(IGioHangCuaToiRepository gioHangCuaToiRepository)
        {
            _gioHangCuaToiRepository = gioHangCuaToiRepository;
        }

        public Task<GioHangCuaToi> GetByIdAsync(int gioHangID) => _gioHangCuaToiRepository.GetByIdAsync(gioHangID);
        public Task<IEnumerable<GioHangCuaToi>> GetByCaKoiIdAsync(int caKoiID) => _gioHangCuaToiRepository.GetByCaKoiIdAsync(caKoiID);

        // Đảm bảo GetAllAsync được triển khai đúng
        public Task<IEnumerable<GioHangCuaToi>> GetAllAsync() => _gioHangCuaToiRepository.GetAllAsync();

        public Task<GioHangCuaToi> AddAsync(GioHangCuaToi gioHangCuaToi) => _gioHangCuaToiRepository.AddAsync(gioHangCuaToi);
        public Task<GioHangCuaToi> UpdateAsync(GioHangCuaToi gioHangCuaToi) => _gioHangCuaToiRepository.UpdateAsync(gioHangCuaToi);
        public Task<bool> DeleteAsync(int gioHangID) => _gioHangCuaToiRepository.DeleteAsync(gioHangID);
    }
}
