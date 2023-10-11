using System;
using System.Collections.Generic;

namespace Health_Insurance.Models;

public partial class Beneficiary
{
    public decimal Beneficiaryid { get; set; }

    public decimal? Subscriptionid { get; set; }

    public string? Fullname { get; set; }

    public string? Relationship { get; set; }

    public string? Proofimage { get; set; }

    public string? Status { get; set; }

    public virtual Subscription? Subscription { get; set; }
}
