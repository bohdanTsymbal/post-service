using System;
using System.Collections.Generic;

namespace PostServiceWebApplication.Models;

public partial class Client
{
    public string PhoneNumber { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public virtual ICollection<Parcel> ParcelClientFromNumberNavigations { get; } = new List<Parcel>();

    public virtual ICollection<Parcel> ParcelClientToNumberNavigations { get; } = new List<Parcel>();
}
    