using System;
using System.Collections.Generic;

namespace EaseTrail.WebApp.Models;

public partial class AccountPlan
{
    public string Id { get; set; } = null!;

    public string AccountId { get; set; }

    public string PlanId { get; set; }

    public int PaymentStatus { get; set; }

    public decimal Discount { get; set; }

    public virtual Account Account { get; set; }

    public virtual Plan Plan { get; set; }
}
