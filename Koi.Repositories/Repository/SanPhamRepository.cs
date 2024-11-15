using Koi.Repositories.Entities;
using Koi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koi.Repositories
{
    public class SanPhamRepository : ISanPhamRepository
    {
        private readonly KoifarmContext _context;

        public SanPhamRepository(KoifarmContext context)
        {
            _context = context;
        }

        // Lấy SanPham theo ID
        public async Task<SanPham> GetByIdAsync(int sanPhamID)
        {
            return await _context.SanPhams  // Use SanPhams instead of SanPham
                                 .FirstOrDefaultAsync(s => s.SanPhamId == sanPhamID);
        }

        // Lấy tất cả các SanPham
        public async Task<IEnumerable<SanPham>> GetAllAsync()
        {
            return await _context.SanPhams.ToListAsync();  // Use SanPhams instead of SanPham
        }

        // Thêm một SanPham mới
        public async Task<SanPham> AddAsync(SanPham sanPham)
        {
            await _context.SanPhams.AddAsync(sanPham);  // Use SanPhams instead of SanPham
            await _context.SaveChangesAsync();
            return sanPham;
        }

        // Cập nhật một SanPham
        public async Task<SanPham> UpdateAsync(SanPham sanPham)
        {
            _context.SanPhams.Update(sanPham);  // Use SanPhams instead of SanPham
            await _context.SaveChangesAsync();
            return sanPham;
        }

        // Xóa SanPham theo ID
        public async Task<bool> DeleteAsync(int sanPhamID)
        {
            var sanPham = await GetByIdAsync(sanPhamID);
            if (sanPham == null)
            {
                return false;
            }

            _context.SanPhams.Remove(sanPham);  // Use SanPhams instead of SanPham
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
