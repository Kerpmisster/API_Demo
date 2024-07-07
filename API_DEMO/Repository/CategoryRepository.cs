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

        public async Task<Category> CreateAsync(Category categoriesModel)
        {
            await apiDemoContext.Categories.AddAsync(categoriesModel);
            await apiDemoContext.SaveChangesAsync();
            return categoriesModel; 
        }

        public async Task<Category?> DeleteAsync(int id)
        {
            var categoriesModel = await apiDemoContext.Categories.FirstOrDefaultAsync(u => u.CategoryId == id);

            if (categoriesModel == null)
            {
                return null;
            }

            apiDemoContext.Categories.Remove(categoriesModel);
            await apiDemoContext.SaveChangesAsync();
            return categoriesModel; ;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await apiDemoContext.Categories.Include(u => u.Products).ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await apiDemoContext.Categories.Include(u => u.Products).FirstOrDefaultAsync(c=>c.CategoryId==id);
        }

        public async Task<Category?> UpdateAsync(int id, Category categoriesModel)
        {
            var existingCategory = await apiDemoContext.Categories.FirstOrDefaultAsync(u => u.CategoryId == id);

            if (existingCategory == null)
            {
                return null;
            }

            existingCategory.Name = categoriesModel.Name;
            existingCategory.Description = categoriesModel.Description;
            existingCategory.CreatedBy = categoriesModel.CreatedBy;
            existingCategory.EditedBy = categoriesModel.EditedBy;


            await apiDemoContext.SaveChangesAsync();

            return existingCategory;
        }
    }
}
