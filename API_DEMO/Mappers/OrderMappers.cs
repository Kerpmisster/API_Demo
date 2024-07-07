using API_DEMO.DTOs.Order;
using API_DEMO.Models;

namespace API_DEMO.Mappers
{
    public static class OrderMappers
    {
        public static OrderDTOs ToOrderFromDTOs(this Order orderModel)
        {
            return new OrderDTOs
            {
               OrdersId = orderModel.OrdersId,
               Id = orderModel.Id,
               Address = orderModel.Address,
               AccountCode = orderModel.AccountCode,
               PaymentMethods = orderModel.PaymentMethods,
               CreatedAt = orderModel.CreatedAt,
               OrderDetails = orderModel.OrdersDetails.Select(e=>e.ToOrderDetailFromDTOs()).ToList()
            };
        }

        public static Order ToOrderCreateFromDTOs(this CreateOrderDTOs orderDTOs, int id)
        {
            return new Order
            {
                Id = id,
                Address = orderDTOs.Address,
                AccountCode = orderDTOs.AccountCode,
                PaymentMethods = orderDTOs.PaymentMethods
            };
        }

        public static Order ToOrderUpdateFromDTOs(this UpdateOrderDTOs orderDTOs)
        {
            return new Order
            {
                Address = orderDTOs.Address,
                AccountCode = orderDTOs.AccountCode,
                PaymentMethods = orderDTOs.PaymentMethods
            };
        }
    }
}
