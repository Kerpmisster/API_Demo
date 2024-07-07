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
        public async Task<User> CreateAsync(User usersModel)
        {
            await apiDemoContext.Users.AddAsync(usersModel);
            await apiDemoContext.SaveChangesAsync();
            return usersModel;
        }

        public async Task<User?> DeleteAsync(int id)
        {
            var usersModel = await apiDemoContext.Users.FirstOrDefaultAsync(u=>u.Id==id);

            if (usersModel == null) 
            { 
                return null;
            }

            apiDemoContext.Users.Remove(usersModel);
            await apiDemoContext.SaveChangesAsync();
            return usersModel;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await apiDemoContext.Users.Include(u=>u.Orders).ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await apiDemoContext.Users.Include(u => u.Orders).FirstOrDefaultAsync(u=>u.Id==id);
        }

        public async Task<User?> UpdateAsync(int id, User updateDto)
        {
            var existingUser = await apiDemoContext.Users.FirstOrDefaultAsync(u=>u.Id==id);

            if (existingUser == null) 
            {
                return null ;
            }

            existingUser.Name = updateDto.Name;
            existingUser.Email = updateDto.Email;
            existingUser.Password = updateDto.Password;

            await apiDemoContext.SaveChangesAsync();

            return existingUser;
        }

        public async Task<bool> UserExists(int id)
        {
            return await apiDemoContext.Users.AnyAsync(u=>u.Id==id);
        }
    }
}
