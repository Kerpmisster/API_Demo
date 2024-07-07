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
        public async Task<OrdersDetail> CreateAsync(OrdersDetail ordersDetailModel)
        {
            await apiDemoContext.OrdersDetails.AddAsync(ordersDetailModel);
            await apiDemoContext.SaveChangesAsync();
            return ordersDetailModel;
        }

        public async Task<OrdersDetail?> DeleteAsync(int id)
        {
            var ordersDetailModel = await apiDemoContext.OrdersDetails.FirstOrDefaultAsync(u => u.Id == id);

            if (ordersDetailModel == null)
            {
                return null;
            }

            apiDemoContext.OrdersDetails.Remove(ordersDetailModel);
            await apiDemoContext.SaveChangesAsync();
            return ordersDetailModel;
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

        public async Task<OrdersDetail?> UpdateAsync(int id, OrdersDetail ordersDetailModel)
        {
            var existingOrdersDetail = await apiDemoContext.OrdersDetails.FirstOrDefaultAsync(u => u.Id == id);

            if (existingOrdersDetail == null)
            {
                return null;
            }

            existingOrdersDetail.Quantity = ordersDetailModel.Quantity;
            existingOrdersDetail.Price = ordersDetailModel.Price;
            existingOrdersDetail.TotalAmount    = ordersDetailModel.TotalAmount;

            await apiDemoContext.SaveChangesAsync();

            return existingOrdersDetail;
        }
    }
}
