using System;
using System.Collections.Generic;

namespace API_DEMO.Models;

public partial class OrdersDetail
{
    public int Id { get; set; }

    public int OrdersId { get; set; }

    public int SpId { get; set; }

    public string? Quantity { get; set; }

    public decimal? Price { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual Order Orders { get; set; } = null!;

    public virtual Product Sp { get; set; } = null!;
}
