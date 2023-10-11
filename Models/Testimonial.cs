using System;
using System.Collections.Generic;

namespace Health_Insurance.Models;

public partial class Testimonial
{
    public decimal Testimonialid { get; set; }

    public decimal? Userid { get; set; }

    public string? Username { get; set; }

    public string? Message { get; set; }

    public string? Status { get; set; }

    public string? Image { get; set; }

    public virtual Userccount? User { get; set; }
}
