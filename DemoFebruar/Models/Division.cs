using System;
using System.Collections.Generic;

namespace DemoFebruar.Models;

public partial class Division
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Division> IdDivisionOtdels { get; set; } = new List<Division>();

    public virtual ICollection<Division> IdDivisionPotOtdels { get; set; } = new List<Division>();

    public virtual ICollection<Employee> IdEmployes { get; set; } = new List<Employee>();
}
