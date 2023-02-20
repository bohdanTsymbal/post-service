using System;
using System.Collections.Generic;

namespace PostServiceWebApplication.Models;

public partial class LocationType
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public TimeSpan OpenTime { get; set; }

    public TimeSpan CloseTime { get; set; }

    public virtual ICollection<Location> Locations { get; } = new List<Location>();
}
