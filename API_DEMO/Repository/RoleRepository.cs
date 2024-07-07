using API_DEMO.Interface;
using API_DEMO.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Role>> GetAllAsync()
        {
            return await apiDemoContext.Roles.Include(u => u.Users).ToListAsync();
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            return await apiDemoContext.Roles.Include(u => u.Users).FirstOrDefaultAsync(r=>r.RoleId==id);
        }

        public async Task<bool> RoleExists(int id)
        {
            return await apiDemoContext.Roles.AnyAsync(r => r.RoleId == id);
        }

        public Task<Role?> UpdateAsync(int id, Role updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
