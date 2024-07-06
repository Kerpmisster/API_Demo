using API_DEMO.Interface;
using API_DEMO.Models;

namespace API_DEMO.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApiDemoContext apiDemoContext;
        public ProductRepository(ApiDemoContext apiDemoContext)
        {
            this.apiDemoContext = apiDemoContext;
        }
        public Task<Product> CreateAsync(Product productsModel)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ProductExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> UpdateAsync(int id, Product updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
