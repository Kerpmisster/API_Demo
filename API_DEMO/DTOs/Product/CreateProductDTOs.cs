namespace API_DEMO.DTOs.Product
{
    public class CreateProductDTOs
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public string Quantity { get; set; } = null!;

        public decimal Price { get; set; }

        public string Image { get; set; } = null!;

        public string CreatedBy { get; set; } = null!;
        public string EditedBy { get; set; } = null!;

    }
}
