using System;
using System.Collections.Generic;

namespace API_DEMO.Models;

public partial class Product
{
    public int SpId { get; set; }

    public string Name { get; set; } = null!;

    public int? CategoryId { get; set; }

    public string? Description { get; set; }

    public string Quantity { get; set; } = null!;

    public decimal Price { get; set; }

    public string Image { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public string EditedBy { get; set; } = null!;

    public DateTime? EditedAt { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrdersDetail> OrdersDetails { get; set; } = new List<OrdersDetail>();
}
