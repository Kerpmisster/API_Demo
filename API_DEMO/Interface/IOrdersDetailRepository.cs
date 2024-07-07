using API_DEMO.Models;

namespace API_DEMO.Interface
{
    public interface IOrdersDetailRepository
    {
        Task<List<OrdersDetail>> GetAllAsync();
        Task<OrdersDetail?> GetByIdAsync(int id);
        Task<OrdersDetail> CreateAsync(OrdersDetail ordersDetailModel);
        Task<OrdersDetail?> UpdateAsync(int id, OrdersDetail ordersDetailModel);
        Task<OrdersDetail?> DeleteAsync(int id);
        Task<bool> OrderDetailExists(int id);
    }
}
