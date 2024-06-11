using System;
using System.Collections.Generic;

namespace BussinessObject.Model;

public partial class Transaction
{
    public string TransactionId { get; set; } = null!;

    public int BuyerId { get; set; }

    public int SellerId { get; set; }

    public int ProductId { get; set; }

    public string Status { get; set; } = null!;

    public virtual Buyer Buyer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Seller Seller { get; set; } = null!;
}
