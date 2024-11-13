using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Koi.Repositories.Entities;
using Koi.Repositories.Interfaces;

namespace Koi.Repositories
{
    public class KyGuiRepository : IKyGuiRepository
    {
        private readonly KoifarmContext _context;

        public KyGuiRepository(KoifarmContext context)
        {
            _context = context;
        }

        public async Task<KyGui> GetByIdAsync(int kyGuiID)
        {
            return await _context.KyGuis.FindAsync(kyGuiID); // Ensure you have a DbSet<KyGui> in your context
        }

        public async Task<IEnumerable<KyGui>> GetByLichSuKyGuiIdAsync(int lichSuKyGuiID)
        {
            return await _context.KyGuis.Where(k => k.LichSuKyGuiId == lichSuKyGuiID).ToListAsync();
        }

        public async Task<KyGui> AddAsync(KyGui kyGui)
        {
            _context.KyGuis.Add(kyGui);
            await _context.SaveChangesAsync();
            return kyGui;
        }

        public async Task<KyGui> UpdateAsync(KyGui kyGui)
        {
            _context.Entry(kyGui).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return kyGui;
        }

        public async Task<bool> DeleteAsync(int kyGuiID)
        {
            var kyGui = await _context.KyGuis.FindAsync(kyGuiID);
            if (kyGui == null) return false;

            _context.KyGuis.Remove(kyGui);
            await _context.SaveChangesAsync();
            return true;
        }

        //public Task<IEnumerable<KyGui>> GetByLichSuKyGuiIdAsync(int lichSuKyGuiID)
        //{
        //    throw new NotImplementedException();
        //}
    }
}