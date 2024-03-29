using System;
using System.Collections.Generic;

namespace EaseTrail.WebApp.Models;

public partial class TeamAccount
{
    public string Id { get; set; } = null!;

    public string? AccountId { get; set; }

    public string? TeamId { get; set; }

    public int? MemberType { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Team? Team { get; set; }
}
