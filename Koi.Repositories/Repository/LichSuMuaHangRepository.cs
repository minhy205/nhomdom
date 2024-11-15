using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Koi.Repositories.Entities;
using Koi.Repositories.Interfaces;

namespace Koi.Repositories
{
    public class LichSuMuaHangRepository : ILichSuMuaHangRepository
    {
        private readonly KoifarmContext _context;

        public LichSuMuaHangRepository(KoifarmContext context)
        {
            _context = context;
        }

        public async Task<LichSuMuaHang> GetByIdAsync(int muaHangID)
        {
            return await _context.LichSuMuaHangs.FindAsync(muaHangID); // Ensure you have a DbSet<LichSuMuaHang> in your context
        }

        public async Task<IEnumerable<LichSuMuaHang>> GetByKhachHangIdAsync(int maKhachHang)
        {
            return await _context.LichSuMuaHangs.Where(l => l.MaKhachHang == maKhachHang).ToListAsync();
        }

        // Thêm phương thức GetAllAsync để lấy tất cả các bản ghi LichSuMuaHang
        public async Task<IEnumerable<LichSuMuaHang>> GetAllAsync()
        {
            return await _context.LichSuMuaHangs.ToListAsync();  // Trả về tất cả bản ghi từ bảng LichSuMuaHang
        }

        public async Task<LichSuMuaHang> AddAsync(LichSuMuaHang lichSuMuaHang)
        {
            _context.LichSuMuaHangs.Add(lichSuMuaHang);
            await _context.SaveChangesAsync();
            return lichSuMuaHang;
        }

        public async Task<LichSuMuaHang> UpdateAsync(LichSuMuaHang lichSuMuaHang)
        {
            _context.Entry(lichSuMuaHang).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return lichSuMuaHang;
        }

        public async Task<bool> DeleteAsync(int muaHangID)
        {
            var lichSuMuaHang = await _context.LichSuMuaHangs.FindAsync(muaHangID);
            if (lichSuMuaHang == null) return false;

            _context.LichSuMuaHangs.Remove(lichSuMuaHang);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
