using System;
using System.Collections.Generic;

namespace ProjectWeb.Models;

public partial class ProductService
{
    public int ServiceId { get; set; }

    public string? ServiceName { get; set; }

    public byte[]? Image { get; set; }

    public virtual ICollection<SubscriptionTier> SubscriptionTiers { get; set; } = new List<SubscriptionTier>();
}
