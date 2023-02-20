using System;
using System.Collections.Generic;

namespace PostServiceWebApplication.Models;

public partial class ParcelHistory
{
    public long Id { get; set; }

    public long LocationId { get; set; }

    public long ParcelId { get; set; }

    public long StatusId { get; set; }

    public DateTime Datetime { get; set; }

    public virtual Location Location { get; set; } = null!;

    public virtual Parcel Parcel { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
