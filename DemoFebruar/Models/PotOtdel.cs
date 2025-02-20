using System;
using System.Collections.Generic;

namespace DemoFebruar.Models;

public partial class PotOtdel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Division> Divisions { get; set; } = new List<Division>();
}
