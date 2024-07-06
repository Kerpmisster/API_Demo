using API_DEMO.DTOs.OrderDetail;
using API_DEMO.Models;

namespace API_DEMO.Mappers
{
    public static class OrderDetailMappers
    {
        public static OrderDetailDTOs ToOrderDetailFromDTOs(this OrdersDetail orderDetailModel)
        {
            return new OrderDetailDTOs
            {
                Id = orderDetailModel.Id,
                OrdersId = orderDetailModel.OrdersId,
                SpId = orderDetailModel.SpId,
                Quantity = orderDetailModel.Quantity,
                Price = orderDetailModel.Price,
                TotalAmount = orderDetailModel.TotalAmount

            };
        }

        public static OrdersDetail ToOrderDetailCreateFromDTOs(this CreateOrderDetailDTOs orderDTOs)
        {
            return new OrdersDetail
            {
                Quantity = orderDTOs.Quantity,
                Price = orderDTOs.Price,
                TotalAmount = orderDTOs.TotalAmount
            };
        }

        public static OrdersDetail ToOrderDetailUpdateFromDTOs(this UpdateOrderDetailDTOs orderDTOs)
        {
            return new OrdersDetail
            {
                Quantity = orderDTOs.Quantity,
                Price = orderDTOs.Price,
                TotalAmount = orderDTOs.TotalAmount
            };
        }
    }
}
