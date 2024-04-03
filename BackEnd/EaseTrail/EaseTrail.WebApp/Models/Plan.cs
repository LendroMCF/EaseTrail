using System;
using System.Collections.Generic;

namespace EaseTrail.WebApp.Models;

public partial class Plan
{
    public string Id { get; set; } = null!;

    public string Name { get; set; }

    public decimal Value { get; set; }

    public string Description { get; set; }

    public int UserLimit { get; set; }

    public int TeamLimit { get; set; }

    public bool ViewDashboard { get; set; }

    public int SupportLevel { get; set; }

    public virtual ICollection<AccountPlan> AccountPlans { get; set; } = new List<AccountPlan>();

    public virtual ICollection<PlanFunction> PlanFunctions { get; set; } = new List<PlanFunction>();
}
