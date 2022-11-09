using System;
using System.Collections.Generic;

namespace NZWalks.NZWalks.Infrastructure.Entities;

public partial class WalkDifficulty
{
    public Guid Id { get; set; }

    public string Code { get; set; }

    public virtual ICollection<Walk> Walks { get; } = new List<Walk>();
}
