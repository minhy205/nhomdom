using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Koi.Repositories.Entities;
using Koi.Repositories.Interfaces;

namespace Koi.Repositories
{
    public class CaKoiRepository : ICaKoiRepository
    {
        private readonly KoifarmContext _context;

        public CaKoiRepository(KoifarmContext context)
        {
            _context = context;
        }

        public async Task<CaKoi> GetByIdAsync(int caKoiID)
        {
            return await _context.CaKois.FindAsync(caKoiID);
        }

        public async Task<IEnumerable<CaKoi>> GetAllAsync()
        {
            return await _context.CaKois.ToListAsync();
        }

        public async Task<CaKoi> AddAsync(CaKoi caKoi)
        {
            _context.CaKois.Add(caKoi);
            await _context.SaveChangesAsync();
            return caKoi;
        }

        public async Task<CaKoi> UpdateAsync(CaKoi caKoi)
        {
            _context.Entry(caKoi).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return caKoi;
        }

        public async Task<bool> DeleteAsync(int caKoiID)
        {
            var caKoi = await _context.CaKois.FindAsync(caKoiID);
            if (caKoi == null) return false;

            _context.CaKois.Remove(caKoi);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}