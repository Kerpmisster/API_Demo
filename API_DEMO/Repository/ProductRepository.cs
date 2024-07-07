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
        public async Task<Product> CreateAsync(Product productsModel)
        {
            await apiDemoContext.Products.AddAsync(productsModel);
            await apiDemoContext.SaveChangesAsync();
            return productsModel;
        }

        public async Task<Product?> DeleteAsync(int id)
        {
            var productsModel = await apiDemoContext.Products.FirstOrDefaultAsync(u => u.SpId == id);

            if (productsModel == null)
            {
                return null;
            }

            apiDemoContext.Products.Remove(productsModel);
            await apiDemoContext.SaveChangesAsync();
            return productsModel;
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

        public async Task<Product?> UpdateAsync(int id, Product updateDto)
        {
            var existingProduct = await apiDemoContext.Products.FirstOrDefaultAsync(u => u.SpId == id);

            if (existingProduct == null)
            {
                return null;
            }

            existingProduct.Name = updateDto.Name;
            existingProduct.Description = updateDto.Description;
            existingProduct.Quantity = updateDto.Quantity;
            existingProduct.Price = updateDto.Price;
            existingProduct.CreatedBy = updateDto.CreatedBy;
            existingProduct.EditedBy = updateDto.EditedBy;

            await apiDemoContext.SaveChangesAsync();

            return existingProduct;
        }
    }
}
