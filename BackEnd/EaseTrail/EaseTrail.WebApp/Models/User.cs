using System;
using System.Collections.Generic;

namespace EaseTrail.WebApp.Models;

public partial class User
{
    public string Id { get; set; } = null!;

    public string? AccountId { get; set; }

    public string? OriginStatusId { get; set; }

    public string? OriginId { get; set; }

    public string? Name { get; set; }

    public int? OriginPaymentStatus { get; set; }

    public virtual Account? Account { get; set; }

    public virtual OriginStatus? OriginStatus { get; set; }
}
