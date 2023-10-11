using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Health_Insurance.Models;

public partial class Userccount
{
    public decimal Userid { get; set; }

    public decimal? Roleid { get; set; }

    public string? Fullname { get; set; }

    [NotMapped]
    public IFormFile? ImageFile { get; set; }

    public string? Image { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Phonenumber { get; set; }

    public string? Gender { get; set; }

    public string? City { get; set; }

    public string? Status { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();

    public virtual ICollection<Testimonial> Testimonials { get; set; } = new List<Testimonial>();
}
