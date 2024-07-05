using System;
using System.Collections.Generic;

namespace API_DEMO.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? Created { get; set; }

    public bool? Status { get; set; }

    public int? RoleId { get; set; }

    public string? AvatarImg { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role? Role { get; set; }
}
