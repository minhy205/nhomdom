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
            // Gọi phương thức từ repository để lấy DanhGia theo ID
            return await _danhGiaRepository.GetByIdAsync(danhGiaID);
        }

        public async Task<IEnumerable<DanhGia>> GetByCaKoiIdAsync(int caKoiID)
        {
            // Gọi phương thức từ repository để lấy danh sách đánh giá theo CaKoiID
            return await _danhGiaRepository.GetByCaKoiIdAsync(caKoiID);
        }

        public async Task<DanhGia> AddAsync(DanhGia danhGia)
        {
            // Gọi phương thức từ repository để thêm một đánh giá mới
            return await _danhGiaRepository.AddAsync(danhGia);
        }

        public async Task<DanhGia> UpdateAsync(DanhGia danhGia)
        {
            // Gọi phương thức từ repository để cập nhật đánh giá
            return await _danhGiaRepository.UpdateAsync(danhGia);
        }

        public async Task<bool> DeleteAsync(int danhGiaID)
        {
            // Gọi phương thức từ repository để xóa một đánh giá theo ID
            return await _danhGiaRepository.DeleteAsync(danhGiaID);
        }
    }
}
