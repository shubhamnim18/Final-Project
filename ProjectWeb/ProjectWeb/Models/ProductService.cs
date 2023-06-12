using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWeb.Models;

public partial class ProductService
{
    public int ServiceId { get; set; }

    public string? ServiceName { get; set; }

    public string? Image { get; set; }
    [NotMapped]
    public IFormFile file { get; set; }

    public virtual ICollection<SubscriptionTier> SubscriptionTiers { get; set; } = new List<SubscriptionTier>();
}
