namespace API_DEMO.DTOs.OrderDetail
{
    public class OrderDetailDTOs
    {
        public int Id { get; set; }

        public int OrdersId { get; set; }

        public int SpId { get; set; }

        public string? Quantity { get; set; }

        public decimal? Price { get; set; }

        public decimal? TotalAmount { get; set; }
    }
}
