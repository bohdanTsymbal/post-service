using System;
using System.Collections.Generic;

namespace PostServiceWebApplication.Models;

public partial class Location
{
    public long Id { get; set; }

    public string Address { get; set; } = null!;

    public long Capacity { get; set; }

    public long TypeId { get; set; }

    public virtual ICollection<ParcelHistory> ParcelHistories { get; } = new List<ParcelHistory>();

    public virtual LocationType Type { get; set; } = null!;
}
