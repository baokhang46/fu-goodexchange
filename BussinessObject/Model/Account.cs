using System;
using System.Collections.Generic;

namespace BussinessObject.Model;

public partial class Account
{
    public int AccountId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Status { get; set; } = "Active";

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
