using System;
using System.Collections.Generic;

namespace EaseTrail.WebApp.Models;

public partial class PlanFunction
{
    public string Id { get; set; } = null!;

    public string? FunctionId { get; set; }

    public string? PlanId { get; set; }

    public virtual Function? Function { get; set; }

    public virtual Plan? Plan { get; set; }
}
