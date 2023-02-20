using System;
using System.Collections.Generic;

namespace PostServiceWebApplication.Models;

public partial class Parcel
{
    public long Id { get; set; }

    public string ClientFromNumber { get; set; } = null!;

    public string ClientToNumber { get; set; } = null!;

    public long TypeId { get; set; }

    public virtual Client ClientFromNumberNavigation { get; set; } = null!;

    public virtual Client ClientToNumberNavigation { get; set; } = null!;

    public virtual ICollection<ParcelHistory> ParcelHistories { get; } = new List<ParcelHistory>();

    public virtual ParcelType Type { get; set; } = null!;
}
