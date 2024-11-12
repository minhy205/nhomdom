using Koi.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<User> GetByIdAsync(int id);  // Lấy Users theo ID
        Task<IEnumerable<User>> GetAllAsync();  // Lấy tất cả Users
        Task<User> AddAsync(User user);  // Thêm một người dùng mới
        Task<User> UpdateAsync(User user);  // Cập nhật người dùng
        Task<bool> DeleteAsync(int id);  // Xóa người dùng theo ID
    }
}
