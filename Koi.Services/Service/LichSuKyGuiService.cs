using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;
using Koi.Repositories.Interfaces;
using Koi.Services.Interfaces;

namespace Koi.Services
{
    public class LichSuKyGuiService : ILichSuKyGuiService
    {
        private readonly ILichSuKyGuiRepository _lichSuKyGuiRepository;

        public LichSuKyGuiService(ILichSuKyGuiRepository lichSuKyGuiRepository)
        {
            _lichSuKyGuiRepository = lichSuKyGuiRepository;
        }

        public Task<LichSuKyGui> GetByIdAsync(int lichSuKyGuiID) => _lichSuKyGuiRepository.GetByIdAsync(lichSuKyGuiID);
        public Task<IEnumerable<LichSuKyGui>> GetAllAsync() => _lichSuKyGuiRepository.GetAllAsync();
        public Task<LichSuKyGui> AddAsync(LichSuKyGui lichSuKyGui) => _lichSuKyGuiRepository.AddAsync(lichSuKyGui);
        public Task<LichSuKyGui> UpdateAsync(LichSuKyGui lichSuKyGui) => _lichSuKyGuiRepository.UpdateAsync(lichSuKyGui);
        public Task<bool> DeleteAsync(int lichSuKyGuiID) => _lichSuKyGuiRepository.DeleteAsync(lichSuKyGuiID);
    }
}