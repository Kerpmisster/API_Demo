using API_DEMO.Models;

namespace API_DEMO.Interface
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task<Order> CreateAsync(Order stocksModel);
        Task<Order?> UpdateAsync(int id, Order updateDto);
        Task<Order?> DeleteAsync(int id);
        Task<bool> OrderExists(int id);
    }
}
