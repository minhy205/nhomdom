using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;
using Koi.Repositories.Interfaces;
using Koi.Services.Interfaces;

namespace Koi.Services
{
    public class NguoiDungService : INguoiDungService
    {
        private readonly INguoiDungRepository _nguoiDungRepository;

        public NguoiDungService(INguoiDungRepository nguoiDungRepository)
        {
            _nguoiDungRepository = nguoiDungRepository;
        }

        public Task<NguoiDung> GetByIdAsync(int khachHangID) => _nguoiDungRepository.GetByIdAsync(khachHangID);
        public Task<IEnumerable<NguoiDung>> GetByUserIdAsync(int userID) => _nguoiDungRepository.GetByUserIdAsync(userID);
        public Task<NguoiDung> AddAsync(NguoiDung nguoiDung) => _nguoiDungRepository.AddAsync(nguoiDung);
        public Task<NguoiDung> UpdateAsync(NguoiDung nguoiDung) => _nguoiDungRepository.UpdateAsync(nguoiDung);
        public Task<bool> DeleteAsync(int khachHangID) => _nguoiDungRepository.DeleteAsync(khachHangID);
    }
}