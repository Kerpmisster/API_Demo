namespace API_DEMO.DTOs.Order
{
    public class OrderDTOs
    {
        public int OrdersId { get; set; }

        public int? Id { get; set; }

        public string? Address { get; set; }

        public string AccountCode { get; set; } = null!;

        public string PaymentMethods { get; set; } = null!;

        public DateTime CreatedAt { get; set; }
    }
}
