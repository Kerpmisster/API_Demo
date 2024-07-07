using API_DEMO.Interface;
using API_DEMO.Models;
using Microsoft.EntityFrameworkCore;

namespace API_DEMO.Repository
{
    public class OrdersDetailRepository : IOrdersDetailRepository
    {
        private readonly ApiDemoContext apiDemoContext;
        public OrdersDetailRepository(ApiDemoContext apiDemoContext)
        {
            this.apiDemoContext = apiDemoContext;
        }
        public Task<OrdersDetail> CreateAsync(OrdersDetail ordersDetailModel)
        {
            throw new NotImplementedException();
        }

        public Task<OrdersDetail?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrdersDetail>> GetAllAsync()
        {
            return await apiDemoContext.OrdersDetails.ToListAsync();
        }

        public async Task<OrdersDetail?> GetByIdAsync(int id)
        {
            return await apiDemoContext.OrdersDetails.FirstOrDefaultAsync(o=>o.Id==id);
        }

        public async Task<bool> OrderDetailExists(int id)
        {
            return await apiDemoContext.OrdersDetails.AnyAsync(o => o.Id == id);
        }

        public Task<OrdersDetail?> UpdateAsync(int id, OrdersDetail ordersDetailModel)
        {
            throw new NotImplementedException();
        }
    }
}
