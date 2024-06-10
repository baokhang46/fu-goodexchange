using System;
using System.Collections.Generic;

namespace BussinessObject.Model;

public partial class User
{
    public int UserId { get; set; }

    public int AccountId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<Buyer> Buyers { get; set; } = new List<Buyer>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Seller> Sellers { get; set; } = new List<Seller>();
}
