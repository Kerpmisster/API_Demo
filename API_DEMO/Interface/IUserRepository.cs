using API_DEMO.Models;

namespace API_DEMO.Interface
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User> CreateAsync(User usersModel);
        Task<User?> UpdateAsync(int id, User updateDto);
        Task<User?> DeleteAsync(int id);
        Task<bool> UserExists(int id);
    }
}
