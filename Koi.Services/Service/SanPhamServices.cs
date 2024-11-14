using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;
using Koi.Repositories.Interfaces;
using Koi.Services.Interfaces;

namespace Koi.Services
{
    public class SanPhamServices : ISanPhamServices
    {
        private readonly IRepository<SanPham> _sanPhamRepository;

        public SanPhamServices(IRepository<SanPham> sanPhamRepository)
        {
            _sanPhamRepository = sanPhamRepository;
        }

        public async Task<SanPham> GetByIdAsync(int sanPhamID)
        {
            return await _sanPhamRepository.GetByIdAsync(sanPhamID);
        }

        public async Task<IEnumerable<SanPham>> GetAllAsync()
        {
            return await _sanPhamRepository.GetAllAsync();
        }

        public async Task<SanPham> AddAsync(SanPham sanPham)
        {
            await _sanPhamRepository.AddAsync(sanPham);
            return sanPham;
        }

        public async Task<SanPham> UpdateAsync(SanPham sanPham)
        {
            await _sanPhamRepository.UpdateAsync(sanPham);
            return sanPham;
        }

        public async Task<bool> DeleteAsync(int sanPhamID)
        {
            await _sanPhamRepository.DeleteAsync(sanPhamID);
            return true;
        }
    }
}
