using System;
using System.Collections.Generic;

namespace Health_Insurance.Models;

public partial class Payment
{
    public decimal Paymentid { get; set; }

    public decimal? Userid { get; set; }

    public decimal? Subscriptionid { get; set; }

    public DateTime? Paymentdate { get; set; }

    public decimal? Amount { get; set; }

    public virtual Subscription? Subscription { get; set; }

    public virtual Userccount? User { get; set; }
}
