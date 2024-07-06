using API_DEMO.Interface;
using API_DEMO.Models;

namespace API_DEMO.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApiDemoContext apiDemoContext;
        public UserRepository(ApiDemoContext apiDemoContext)
        {
            this.apiDemoContext = apiDemoContext;
        }
        public Task<User> CreateAsync(User stocksModel)
        {
            throw new NotImplementedException();
        }

        public Task<User?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> UpdateAsync(int id, User updateDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
