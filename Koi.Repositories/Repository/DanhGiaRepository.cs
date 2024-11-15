using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Koi.Repositories.Entities;
using Koi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Koi.Repositories
{
    public class DanhGiaRepository : IDanhGiaRepository
    {
        private readonly KoifarmContext _context;

        public DanhGiaRepository(KoifarmContext context)
        {
            _context = context;
        }

        // Lấy tất cả các bản ghi trong bảng DanhGia
        public async Task<IEnumerable<DanhGia>> GetAllAsync()
        {
            return await _context.DanhGia.ToListAsync();
        }

        // Lấy đánh giá theo ID
        public async Task<DanhGia> GetByIdAsync(int danhGiaId)
        {
            return await _context.DanhGia.FindAsync(danhGiaId);
        }

        // Lấy đánh giá theo ID của CaKoi
        public async Task<IEnumerable<DanhGia>> GetByCaKoiIdAsync(int caKoiId)
        {
            return await _context.DanhGia
                                 .Where(d => d.CaKoiId == caKoiId)
                                 .ToListAsync();
        }

        // Thêm mới một đánh giá
        public async Task<DanhGia> AddAsync(DanhGia danhGia)
        {
            _context.DanhGia.Add(danhGia);
            await _context.SaveChangesAsync();
            return danhGia;
        }

        // Cập nhật một đánh giá
        public async Task<DanhGia> UpdateAsync(DanhGia danhGia)
        {
            _context.DanhGia.Update(danhGia);
            await _context.SaveChangesAsync();
            return danhGia;
        }

        // Xóa một đánh giá
        public async Task<bool> DeleteAsync(int danhGiaId)
        {
            var danhGia = await _context.DanhGia.FindAsync(danhGiaId);
            if (danhGia == null) return false;

            _context.DanhGia.Remove(danhGia);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
