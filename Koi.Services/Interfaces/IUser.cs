using Koi.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi.Services.Interfaces
{
    internal interface IUser
    {
    }
    public interface IUserServices
    {
        Task<User> GetByIdAsync(int id);  // Lấy User theo ID
        Task<IEnumerable<User>> GetAllAsync();  // Lấy tất cả Users
        Task<User> AddUserAsync(User user);  // Thêm một người dùng mới
        Task<User> UpdateUserAsync(User user);  // Cập nhật người dùng
        Task<bool> DeleteUserAsync(int id);  // Xóa người dùng theo ID
    }
}
