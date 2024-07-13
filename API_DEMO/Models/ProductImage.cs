namespace API_DEMO.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public int SpId { get; set; }
        public string? Name { get; set; } 
        public IFormFile Image { get; set; }
        public virtual Product? Product { get; set; }
    }
}
