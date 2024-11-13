using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Koi.Repositories.Entities;
using Koi.Repositories.Interfaces;

namespace Koi.Repositories
{
    public class LichSuKyGuiRepository : ILichSuKyGuiRepository
    {
        private readonly KoifarmContext _context;

        public LichSuKyGuiRepository(KoifarmContext context)
        {
            _context = context;
        }

        public async Task<LichSuKyGui> GetByIdAsync(int lichSuKyGuiID)
        {
            return await _context.LichSuKyGuis.FindAsync(lichSuKyGuiID); // Ensure you have a DbSet<LichSuKyGui> in your context
        }

        public async Task<IEnumerable<LichSuKyGui>> GetAllAsync()
        {
            return await _context.LichSuKyGuis.ToListAsync();
        }

        public async Task<LichSuKyGui> AddAsync(LichSuKyGui lichSuKyGui)
        {
            _context.LichSuKyGuis.Add(lichSuKyGui);
            await _context.SaveChangesAsync();
            return lichSuKyGui;
        }

        public async Task<LichSuKyGui> UpdateAsync(LichSuKyGui lichSuKyGui)
        {
            _context.Entry(lichSuKyGui).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return lichSuKyGui;
        }

        public async Task<bool> DeleteAsync(int lichSuKyGuiID)
        {
            var lichSuKyGui = await _context.LichSuKyGuis.FindAsync(lichSuKyGuiID);
            if (lichSuKyGui == null) return false;

            _context.LichSuKyGuis.Remove(lichSuKyGui);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}