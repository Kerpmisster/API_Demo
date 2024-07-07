using API_DEMO.Interface;
using API_DEMO.Models;
using Microsoft.EntityFrameworkCore;

namespace API_DEMO.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApiDemoContext apiDemoContext;
        public UserRepository(ApiDemoContext apiDemoContext)
        {
            this.apiDemoContext = apiDemoContext;
        }
        public Task<User> CreateAsync(User usersModel)
        {
            throw new NotImplementedException();
        }

        public Task<User?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await apiDemoContext.Users.Include(u=>u.Orders).ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await apiDemoContext.Users.Include(u => u.Orders).FirstOrDefaultAsync(u=>u.Id==id);
        }

        public Task<User?> UpdateAsync(int id, User updateDto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UserExists(int id)
        {
            return await apiDemoContext.Users.AnyAsync(u=>u.Id==id);
        }
    }
}
