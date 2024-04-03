using System;
using System.Collections.Generic;

namespace EaseTrail.WebApp.Models;

public partial class AccountDetail
{
    public string Id { get; set; } = null!;

    public string AccountId { get; set; }

    public string Name { get; set; }

    public byte[] Picture { get; set; }

    public virtual Account Account { get; set; }
}
