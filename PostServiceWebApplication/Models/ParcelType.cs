using System;
using System.Collections.Generic;

namespace PostServiceWebApplication.Models;

public partial class ParcelType
{
    public long Id { get; set; }

    public long Length { get; set; }

    public long Width { get; set; }

    public long Height { get; set; }

    public bool IsFragile { get; set; }

    public long ShipmentCost { get; set; }

    public virtual ICollection<Parcel> Parcels { get; } = new List<Parcel>();
}
