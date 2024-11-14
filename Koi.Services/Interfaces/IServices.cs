using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi.Services.Interfaces
{
    public interface IServices<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();  // Lấy tất cả các thực thể
        Task<TEntity> GetByIdAsync(int id);  // Lấy thực thể theo ID
        Task AddAsync(TEntity entity);  // Thêm một thực thể mới
        Task UpdateAsync(TEntity entity);  // Cập nhật một thực thể
        Task DeleteAsync(int id);  // Xóa thực thể theo ID
    }
}
