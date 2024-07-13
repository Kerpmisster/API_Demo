using System;
using System.Collections.Generic;

namespace API_DEMO.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? Created { get; set; } = DateTime.Now;

    public string? Description { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
