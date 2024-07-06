using API_DEMO.Models;

namespace API_DEMO.Interface
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllAsync();
        Task<Role?> GetByIdAsync(int id);
        Task<Role> CreateAsync(Role roleModel);
        Task<Role?> UpdateAsync(int id, Role updateDto);
        Task<Role?> DeleteAsync(int id);
        Task<bool> RoleExists(int id);
    }
}
