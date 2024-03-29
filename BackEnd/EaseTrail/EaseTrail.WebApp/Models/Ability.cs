using System;
using System.Collections.Generic;

namespace EaseTrail.WebApp.Models;

public partial class Ability
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public int? CreationType { get; set; }

    public virtual ICollection<CollaboratorAbility> CollaboratorAbilities { get; set; } = new List<CollaboratorAbility>();
}
