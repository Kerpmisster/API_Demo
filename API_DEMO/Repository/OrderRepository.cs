using API_DEMO.Interface;
using API_DEMO.Models;
using Microsoft.EntityFrameworkCore;

namespace API_DEMO.Repository
{
    public class OrderRepository : IOrdersRepository
    {
        private readonly ApiDemoContext apiDemoContext;
        public OrderRepository(ApiDemoContext apiDemoContext)
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

        public async Task<List<Order>> GetAllAsync()
        {
            return await apiDemoContext.Orders.Include(u => u.OrdersDetails).ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await apiDemoContext.Orders.Include(u => u.OrdersDetails).FirstOrDefaultAsync(o=>o.OrdersId==id);
        }

        public async Task<bool> OrderExists(int id)
        {
            return await apiDemoContext.Orders.AnyAsync(o => o.OrdersId == id);
        }

        public Task<Order?> UpdateAsync(int id, Order updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
