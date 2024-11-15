using Koi.Repositories.Interfaces;
using Koi.Repositories.Entities;
using Koi.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Koi.Services
{
    public class SanPhamServices : ISanPhamServices
    {
        private readonly IRepository<SanPham> _sanPhamRepository;

        public SanPhamServices(IRepository<SanPham> sanPhamRepository)
        {
            _sanPhamRepository = sanPhamRepository;
        }

        public async Task<SanPham> GetByIdAsync(int sanPhamId)
        {
            return await _sanPhamRepository.GetByIdAsync(sanPhamId);
        }

        public async Task<IEnumerable<SanPham>> GetAllAsync()
        {
            return await _sanPhamRepository.GetAllAsync();
        }

        public async Task<SanPham> AddSanPhamAsync(SanPham sanPham)
        {
            return await _sanPhamRepository.AddAsync(sanPham);
        }

        public async Task<SanPham> UpdateSanPhamAsync(SanPham sanPham)
        {
            return await _sanPhamRepository.UpdateAsync(sanPham);
        }

        public async Task<bool> DeleteAsync(int sanPhamId)
        {
            return await _sanPhamRepository.DeleteAsync(sanPhamId);
        }
    }
}
