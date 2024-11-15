using Koi.Repositories.Entities;
using Koi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koi.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly KoifarmContext _context;

        // Constructor nhận DbContext qua Dependency Injection
        public Repository(KoifarmContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity); // Thêm entity vào DbContext
            await _context.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu
            return entity; // Trả về entity đã thêm
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity); // Cập nhật entity trong DbContext
            await _context.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu
            return entity; // Trả về entity đã cập nhật
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id); // Tìm entity theo id
            if (entity == null)
                return false; // Nếu không tìm thấy entity, trả về false

            _context.Set<T>().Remove(entity); // Xóa entity khỏi DbContext
            await _context.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu
            return true; // Trả về true nếu xóa thành công
        }
    }
}
