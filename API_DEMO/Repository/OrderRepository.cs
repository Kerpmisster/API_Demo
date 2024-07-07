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
        public async Task<Order> CreateAsync(Order ordersModel)
        {
            await apiDemoContext.Orders.AddAsync(ordersModel);
            await apiDemoContext.SaveChangesAsync();
            return ordersModel;
        }

        public async Task<Order?> DeleteAsync(int id)
        {
            var ordersModel = await apiDemoContext.Orders.FirstOrDefaultAsync(u => u.OrdersId == id);

            if (ordersModel == null)
            {
                return null;
            }

            apiDemoContext.Orders.Remove(ordersModel);
            await apiDemoContext.SaveChangesAsync();
            return ordersModel;
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

        public async Task<Order?> UpdateAsync(int id, Order updateDto)
        {
            var existingOrder = await apiDemoContext.Orders.FirstOrDefaultAsync(u => u.OrdersId == id);

            if (existingOrder == null)
            {
                return null;
            }

            existingOrder.Address = updateDto.Address;
            existingOrder.AccountCode = updateDto.AccountCode;
            existingOrder.PaymentMethods = updateDto.PaymentMethods;

            await apiDemoContext.SaveChangesAsync();

            return existingOrder;
        }
    }
}
