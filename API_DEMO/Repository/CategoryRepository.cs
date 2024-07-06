using API_DEMO.Interface;
using API_DEMO.Models;

namespace API_DEMO.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApiDemoContext apiDemoContext;
        public CategoryRepository(ApiDemoContext apiDemoContext)
        {
            this.apiDemoContext = apiDemoContext;
        }
        public Task<bool> CategoryExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> CreateAsync(Category categoriesModel)
        {
            throw new NotImplementedException();
        }

        public Task<Category?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category?> UpdateAsync(int id, Category categoriesModel)
        {
            throw new NotImplementedException();
        }
    }
}
