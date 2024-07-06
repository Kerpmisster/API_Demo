using API_DEMO.Models;
using System.Xml.Linq;

namespace API_DEMO.Interface
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<Category> CreateAsync(Category categoriesModel);
        Task<Category?> UpdateAsync(int id, Category categoriesModel);
        Task<Category?> DeleteAsync(int id);
        Task<bool> CategoryExists(int id);
    }
}
