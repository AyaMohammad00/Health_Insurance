using System;
using System.Collections.Generic;

namespace Health_Insurance.Models;

public partial class Bank
{
    public decimal Bankid { get; set; }

    public decimal? Cardnumber { get; set; }

    public string? Ownername { get; set; }

    public decimal? Balance { get; set; }

    public int? Cvv { get; set; }
}
