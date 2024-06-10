using System;
using System.Collections.Generic;

namespace BussinessObject.Model;

public partial class Report
{
    public int ReportId { get; set; }

    public int BuyerId { get; set; }

    public int SellerId { get; set; }

    public string? Description { get; set; }

    public DateOnly? ReportDate { get; set; }

    public string Status { get; set; } = "Active";

    public virtual Buyer Buyer { get; set; } = null!;

    public virtual Seller Seller { get; set; } = null!;
}
