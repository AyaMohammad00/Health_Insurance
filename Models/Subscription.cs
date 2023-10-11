using System;
using System.Collections.Generic;

namespace Health_Insurance.Models;

public partial class Subscription
{
    public decimal Subscriptionid { get; set; }

    public decimal? Userid { get; set; }

    public string? Status { get; set; }

    public DateTime? Subscriptiondate { get; set; }

    public decimal? Amount { get; set; }

    public virtual ICollection<Beneficiary> Beneficiaries { get; set; } = new List<Beneficiary>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Userccount? User { get; set; }
}
