using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Koi.Repositories.Entities;
using Koi.Repositories.Interfaces;

namespace Koi.Repositories
{
    public class NguoiDungRepository : INguoiDungRepository
    {
        private readonly KoifarmContext _context;

        public NguoiDungRepository(KoifarmContext context)
        {
            _context = context;
        }

        public async Task<NguoiDung> GetByIdAsync(int khachHangID)
        {
            return await _context.NguoiDungs.FindAsync(khachHangID); // Ensure you have a DbSet<NguoiDung> in your context
        }

        //public async Task<NguoiDung> GetByUserIdAsync(int userID)
        //{
        //    return await _context.NguoiDungs.Where(n => n.User == userID).ToListAsync();
        //}

        public async Task<NguoiDung> AddAsync(NguoiDung nguoiDung)
        {
            _context.NguoiDungs.Add(nguoiDung);
            await _context.SaveChangesAsync();
            return nguoiDung;
        }

        public async Task<NguoiDung> UpdateAsync(NguoiDung nguoiDung)
        {
            _context.Entry(nguoiDung).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return nguoiDung;
        }

        public async Task<bool> DeleteAsync(int khachHangID)
        {
            var nguoiDung = await _context.NguoiDungs.FindAsync(khachHangID);
            if (nguoiDung == null) return false;

            _context.NguoiDungs.Remove(nguoiDung);
            await _context.SaveChangesAsync();
            return true;
        }

        Task<IEnumerable<NguoiDung>> INguoiDungRepository.GetByUserIdAsync(int userID)
        {
            throw new NotImplementedException();
        }
    }
}