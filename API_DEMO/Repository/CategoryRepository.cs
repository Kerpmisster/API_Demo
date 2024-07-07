using API_DEMO.Interface;
using API_DEMO.Models;
using Microsoft.EntityFrameworkCore;

namespace API_DEMO.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApiDemoContext apiDemoContext;
        public CategoryRepository(ApiDemoContext apiDemoContext)
        {
            this.apiDemoContext = apiDemoContext;
        }
        public async Task<bool> CategoryExists(int id)
        {
            return await apiDemoContext.Categories.AnyAsync(c => c.CategoryId == id);
        }

        public Task<Category> CreateAsync(Category categoriesModel)
        {
            throw new NotImplementedException();
        }

        public Task<Category?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await apiDemoContext.Categories.Include(u => u.Products).ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await apiDemoContext.Categories.Include(u => u.Products).FirstOrDefaultAsync(c=>c.CategoryId==id);
        }

        public Task<Category?> UpdateAsync(int id, Category categoriesModel)
        {
            throw new NotImplementedException();
        }
    }
}
