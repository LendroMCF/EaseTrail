using System;
using System.Collections.Generic;

namespace EaseTrail.WebApp.Models;

public partial class OriginStatus
{
    public string Id { get; set; } = null!;

    public string? AccountId { get; set; }

    public string? Name { get; set; }

    public int? OriginStatus1 { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
