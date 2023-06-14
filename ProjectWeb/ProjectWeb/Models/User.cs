using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWeb.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = " ";

    public string LastName { get; set; } = " ";

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    [NotMapped]
    public string? Token { get; set; }

    public virtual ICollection<UserSubscription> UserSubscriptions { get; set; } = new List<UserSubscription>();
}
