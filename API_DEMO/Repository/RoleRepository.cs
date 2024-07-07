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
        public async Task<Role> CreateAsync(Role roleModel)
        {
            await apiDemoContext.Roles.AddAsync(roleModel);
            await apiDemoContext.SaveChangesAsync();
            return roleModel; 
        }

        public async Task<Role?> DeleteAsync(int id)
        {
            var roleModel = await apiDemoContext.Roles.FirstOrDefaultAsync(u => u.RoleId == id);

            if (roleModel == null)
            {
                return null;
            }

            apiDemoContext.Roles.Remove(roleModel);
            await apiDemoContext.SaveChangesAsync();
            return roleModel; 
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

        public async Task<Role?> UpdateAsync(int id, Role updateDto)
        {
            var existingRole = await apiDemoContext.Roles.FirstOrDefaultAsync(u => u.RoleId == id);

            if (existingRole == null)
            {
                return null;
            }

            existingRole.Name = updateDto.Name;
            existingRole.Description = updateDto.Description;

            await apiDemoContext.SaveChangesAsync();

            return existingRole; 
        }
    }
}
