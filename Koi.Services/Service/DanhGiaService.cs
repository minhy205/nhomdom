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

        public Task<DanhGia> GetByIdAsync(int danhGiaID) => _danhGiaRepository.GetByIdAsync(danhGiaID);
        public Task<IEnumerable<DanhGia>> GetByCaKoiIdAsync(int caKoiID) => _danhGiaRepository.GetByCaKoiIdAsync(caKoiID);
        public Task<DanhGia> AddAsync(DanhGia danhGia) => _danhGiaRepository.AddAsync(danhGia);
        public Task<DanhGia> UpdateAsync(DanhGia danhGia) => _danhGiaRepository.UpdateAsync(danhGia);
        public Task<bool> DeleteAsync(int danhGiaID) => _danhGiaRepository.DeleteAsync(danhGiaID);
    }
}