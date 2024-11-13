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

        //public async Task<DanhGia> GetByIdAsync(int danhGiaID)
        //{
        //    return await _context.DanhGias.FindAsync(danhGiaID);
        //}

        public async Task<IEnumerable<DanhGia>> GetByCaKoiIdAsync(int caKoiID)
        {
            return (IEnumerable<DanhGia>)await _context.DanhGia.Where(d => d.CaKoiId == caKoiID).ToListAsync();
        }

        public async Task<DanhGia> AddAsync(DanhGia danhGia, DanhGium danhgia)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<DanhGium> entityEntry = _context.DanhGia.Add(danhgia);
            await _context.SaveChangesAsync();
            return danhGia;
        }

        public async Task<DanhGia> UpdateAsync(DanhGia danhGia)
        {
            _context.Entry(danhGia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return danhGia;
        }

        public async Task<bool> DeleteAsync(int danhGiaID)
        {
            var danhGia = await _context.DanhGia.FindAsync(danhGiaID);
            if (danhGia == null) return false;

            _context.DanhGia.Remove(danhGia);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<DanhGia> GetByIdAsync(int danhGiaID)
        {
            throw new NotImplementedException();
        }

        public Task<DanhGia> AddAsync(DanhGia danhGia)
        {
            throw new NotImplementedException();
        }
    }
}