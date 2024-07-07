using API_DEMO.Interface;
using API_DEMO.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Product>> GetAllAsync()
        {
            return await apiDemoContext.Products.Include(u => u.OrdersDetails).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await apiDemoContext.Products.Include(u => u.OrdersDetails).FirstOrDefaultAsync(p=>p.SpId==id);
        }

        public async Task<bool> ProductExists(int id)
        {
            return await apiDemoContext.Products.AnyAsync(p => p.SpId == id);
        }

        public Task<Product?> UpdateAsync(int id, Product updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
