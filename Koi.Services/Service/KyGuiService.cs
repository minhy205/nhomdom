using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;
using Koi.Repositories.Interfaces;
using Koi.Services.Interfaces;

namespace Koi.Services
{
    public class KyGuiService : IKyGuiService
    {
        private readonly IKyGuiRepository _kyGuiRepository;

        public KyGuiService(IKyGuiRepository kyGuiRepository)
        {
            _kyGuiRepository = kyGuiRepository;
        }

        public Task<KyGui> GetByIdAsync(int kyGuiID) => _kyGuiRepository.GetByIdAsync(kyGuiID);
        public Task<IEnumerable<KyGui>> GetByLichSuKyGuiIdAsync(int lichSuKyGuiID) => _kyGuiRepository.GetByLichSuKyGuiIdAsync(lichSuKyGuiID);
        public Task<KyGui> AddAsync(KyGui kyGui) => _kyGuiRepository.AddAsync(kyGui);
        public Task<KyGui> UpdateAsync(KyGui kyGui) => _kyGuiRepository.UpdateAsync(kyGui);
        public Task<bool> DeleteAsync(int kyGuiID) => _kyGuiRepository.DeleteAsync(kyGuiID);
    }
}

