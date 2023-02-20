using System;
using System.Collections.Generic;

namespace PostServiceWebApplication.Models;

public partial class Status
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ParcelHistory> ParcelHistories { get; } = new List<ParcelHistory>();
}
