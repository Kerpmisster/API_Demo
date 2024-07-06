using API_DEMO.Models;

namespace API_DEMO.Interface
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product stocksModel);
        Task<Product?> UpdateAsync(int id, Product updateDto);
        Task<Product?> DeleteAsync(int id);
        Task<bool> ProductExists(int id);
    }
}
