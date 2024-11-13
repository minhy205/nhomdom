using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;
using Koi.Repositories.Interfaces;
using Koi.Services.Interfaces;

namespace Koi.Services
{
    public class CaKoiService : ICaKoiService
    {
        private readonly ICaKoiRepository _caKoiRepository;

        public CaKoiService(ICaKoiRepository caKoiRepository)
        {
            _caKoiRepository = caKoiRepository;
        }

        public Task<CaKoi> GetByIdAsync(int caKoiID) => _caKoiRepository.GetByIdAsync(caKoiID);
        public Task<IEnumerable<CaKoi>> GetAllAsync() => _caKoiRepository.GetAllAsync();
        public Task<CaKoi> AddAsync(CaKoi caKoi) => _caKoiRepository.AddAsync(caKoi);
        public Task<CaKoi> UpdateAsync(CaKoi caKoi) => _caKoiRepository.UpdateAsync(caKoi);
        public Task<bool> DeleteAsync(int caKoiID) => _caKoiRepository.DeleteAsync(caKoiID);
    }
}