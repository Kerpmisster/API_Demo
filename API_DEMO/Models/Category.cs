using System;
using System.Collections.Generic;

namespace API_DEMO.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public string EditedBy { get; set; } = null!;

    public DateTime? EditedAt { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
