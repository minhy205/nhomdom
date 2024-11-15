using Koi.Repositories.Entities;

namespace Koi.Services.Interfaces
{
    public interface ISanPhamServices
    {
        Task<IEnumerable<SanPham>> GetAllAsync();
        Task<SanPham> GetByIdAsync(int sanPhamId);
        Task<SanPham> AddSanPhamAsync(SanPham sanPham);
        Task<SanPham> UpdateSanPhamAsync(SanPham sanPham);
        Task<bool> DeleteAsync(int sanPhamId);
    }
}
