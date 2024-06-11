using System;
using System.Collections.Generic;

namespace BussinessObject.Model;

public partial class Product
{
    public int ProductId { get; set; }

    public int SellerId { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public int? CategoryId { get; set; }

    public DateTime? DatePosted { get; set; }

    public string? Status { get; set; }

    public virtual CartItem? CartItem { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Seller Seller { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
