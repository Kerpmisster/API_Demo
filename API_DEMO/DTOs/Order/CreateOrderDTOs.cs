namespace API_DEMO.DTOs.Order
{
    public class CreateOrderDTOs
    {
        public string? Address { get; set; }

        public string AccountCode { get; set; } = null!;

        public string PaymentMethods { get; set; } = null!;

    }
}
