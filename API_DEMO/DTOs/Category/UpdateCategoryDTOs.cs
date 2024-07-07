namespace API_DEMO.DTOs.Category
{
    public class UpdateCategoryDTOs
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string EditedBy { get; set; } = null!;

    }
}
