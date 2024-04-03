using System;
using System.Collections.Generic;

namespace EaseTrail.WebApp.Models;

public partial class Collaborator
{
    public string Id { get; set; } = null!;

    public string AccountId { get; set; }

    public string Name { get; set; }

    public string Link1 { get; set; }

    public string Link2 { get; set; }

    public string Link3 { get; set; }

    public int Available { get; set; }

    public decimal ValuePerHour { get; set; }

    public virtual Account Account { get; set; }

    public virtual ICollection<CollaboratorAbility> CollaboratorAbilities { get; set; } = new List<CollaboratorAbility>();
}
