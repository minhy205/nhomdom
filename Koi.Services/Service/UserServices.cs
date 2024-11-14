using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Entities;
using Koi.Repositories.Interfaces;
using Koi.Services.Interfaces;

namespace Koi.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUsersRepository _usersRepository;

        public UserServices(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _usersRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _usersRepository.GetAllAsync();
        }

        public async Task<User> AddUserAsync(User user)
        {
            return await _usersRepository.AddAsync(user);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            return await _usersRepository.UpdateAsync(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _usersRepository.DeleteAsync(id);
        }
    }
}
