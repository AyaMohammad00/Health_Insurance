using System;
using System.Collections.Generic;

namespace Health_Insurance.Models;

public partial class Role
{
    public decimal Roleid { get; set; }

    public string? Rolename { get; set; }

    public virtual ICollection<Userccount> Userccounts { get; set; } = new List<Userccount>();
}
