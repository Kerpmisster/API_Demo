using System;
using System.Collections.Generic;

namespace API_DEMO.Models;

public partial class Order
{
    public int OrdersId { get; set; }

    public int? Id { get; set; }

    public string? Address { get; set; }

    public string AccountCode { get; set; } = null!;

    public string PaymentMethods { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual User? IdNavigation { get; set; }

    public virtual ICollection<OrdersDetail> OrdersDetails { get; set; } = new List<OrdersDetail>();
}
