using API_DEMO.Interface;
using API_DEMO.Models;

namespace API_DEMO.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApiDemoContext apiDemoContext;
        public RoleRepository(ApiDemoContext apiDemoContext)
        {
            this.apiDemoContext = apiDemoContext;
        }
        public Task<Role> CreateAsync(Role roleModel)
        {
            throw new NotImplementedException();
        }

        public Task<Role?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Role>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Role?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RoleExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Role?> UpdateAsync(int id, Role updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
