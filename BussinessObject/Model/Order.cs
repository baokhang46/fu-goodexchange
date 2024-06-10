using System;
using System.Collections.Generic;

namespace BussinessObject.Model;

public partial class Order
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int? Quantity { get; set; }

    public decimal? TotalPrice { get; set; }

    public int BuyerId { get; set; }

    public int SellerId { get; set; }

    public string TransactionId { get; set; } = null!;

    public virtual Buyer Buyer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Seller Seller { get; set; } = null!;
}
