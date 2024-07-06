namespace API_DEMO.DTOs.Category
{
    public class CategoryDTOs
    {
        public int CategoryId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public string EditedBy { get; set; } = null!;

        public DateTime? EditedAt { get; set; }
    }
}
