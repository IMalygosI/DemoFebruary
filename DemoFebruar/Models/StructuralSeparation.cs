using System;
using System.Collections.Generic;

namespace DemoFebruar.Models;

public partial class StructuralSeparation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Division> Divisions { get; set; } = new List<Division>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Subdivision> Subdivisions { get; set; } = new List<Subdivision>();
}
