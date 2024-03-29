using System;
using System.Collections.Generic;

namespace EaseTrail.WebApp.Models;

public partial class Team
{
    public string Id { get; set; } = null!;

    public string? AccountId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? TeammateCount { get; set; }

    public int? TeamType { get; set; }

    public int? TeamStatus { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<TeamAccount> TeamAccounts { get; set; } = new List<TeamAccount>();
}
