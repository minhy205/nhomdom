using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;
using Koi.Repositories.Interfaces;
using Koi.Services.Interfaces;

namespace Koi.Services
{
    public class DanhGiaService : IDanhGiaService
    {
        private readonly IDanhGiaRepository _danhGiaRepository;

        public DanhGiaService(IDanhGiaRepository danhGiaRepository)
        {
            _danhGiaRepository = danhGiaRepository;
        }

        public async Task<DanhGia> GetByIdAsync(int danhGiaID)
        {
            return await _danhGiaRepository.GetByIdAsync(danhGiaID);
        }

        public async Task<IEnumerable<DanhGia>> GetByCaKoiIdAsync(int caKoiID)
        {
            return await _danhGiaRepository.GetByCaKoiIdAsync(caKoiID);
        }

        public async Task<IEnumerable<DanhGia>> GetAllAsync()
        {
            return await _danhGiaRepository.GetAllAsync();
        }

        public async Task<DanhGia> AddAsync(DanhGia danhGia)
        {
            return await _danhGiaRepository.AddAsync(danhGia); // Make sure this matches the repository definition
        }

        public async Task<DanhGia> UpdateAsync(DanhGia danhGia)
        {
            return await _danhGiaRepository.UpdateAsync(danhGia);
        }

        public async Task<bool> DeleteAsync(int danhGiaID)
        {
            return await _danhGiaRepository.DeleteAsync(danhGiaID);
        }
    }
}
