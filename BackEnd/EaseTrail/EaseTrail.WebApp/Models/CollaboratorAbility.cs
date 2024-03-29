using System;
using System.Collections.Generic;

namespace EaseTrail.WebApp.Models;

public partial class CollaboratorAbility
{
    public string Id { get; set; } = null!;

    public string? CollaboratorId { get; set; }

    public string? AbilityId { get; set; }

    public virtual Ability? Ability { get; set; }

    public virtual Collaborator? Collaborator { get; set; }
}
