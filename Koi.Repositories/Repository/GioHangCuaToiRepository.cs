using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Koi.Repositories.Entities;
using Koi.Repositories.Interfaces;

namespace Koi.Repositories
{
    public class GioHangCuaToiRepository : IGioHangCuaToiRepository
    {
        private readonly KoifarmContext _context;

        public GioHangCuaToiRepository(KoifarmContext context)
        {
            _context = context;
        }

        public async Task<GioHangCuaToi> GetByIdAsync(int gioHangID)
        {
            return await _context.GioHangCuaTois.FindAsync(gioHangID); // Ensure you have a DbSet<GioHangCuaToi> in your context
        }

        public async Task<IEnumerable<GioHangCuaToi>> GetByCaKoiIdAsync(int caKoiID)
        {
            return await _context.GioHangCuaTois.Where(g => g.CaKoiId == caKoiID).ToListAsync();
        }

        public async Task<GioHangCuaToi> AddAsync(GioHangCuaToi gioHangCuaToi)
        {
            _context.GioHangCuaTois.Add(gioHangCuaToi);
            await _context.SaveChangesAsync();
            return gioHangCuaToi;
        }

        public async Task<GioHangCuaToi> UpdateAsync(GioHangCuaToi gioHangCuaToi)
        {
            _context.Entry(gioHangCuaToi).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return gioHangCuaToi;
        }

        public async Task<bool> DeleteAsync(int gioHangID)
        {
            var gioHangCuaToi = await _context.GioHangCuaTois.FindAsync(gioHangID);
            if (gioHangCuaToi == null) return false;

            _context.GioHangCuaTois.Remove(gioHangCuaToi);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}