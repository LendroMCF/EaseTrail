using System;
using System.Collections.Generic;

namespace EaseTrail.WebApp.Models;

public partial class SystemTransaction
{
    public string Id { get; set; } = null!;

    public string? SenderId { get; set; }

    public decimal? Value { get; set; }

    public string? Description { get; set; }

    public virtual Account? Sender { get; set; }
}
