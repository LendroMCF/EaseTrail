using System;
using System.Collections.Generic;

namespace EaseTrail.WebApp.Models;

public partial class Function
{
    public string Id { get; set; } = null!;

    public string Name { get; set; }

    public string Description { get; set; }

    public virtual ICollection<PlanFunction> PlanFunctions { get; set; } = new List<PlanFunction>();
}
