using API_DEMO.Interface;
using API_DEMO.Models;

namespace API_DEMO.Repository
{
    public class OrdersDetailRepository : IOrderRepository
    {
        private readonly ApiDemoContext apiDemoContext;
        public OrdersDetailRepository(ApiDemoContext apiDemoContext)
        {
            this.apiDemoContext = apiDemoContext;
        }
        public Task<Order> CreateAsync(Order ordersModel)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> OrderExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> UpdateAsync(int id, Order updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
