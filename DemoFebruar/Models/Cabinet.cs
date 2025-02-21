using System;
using System.Collections.Generic;

namespace DemoFebruar.Models;

public partial class Cabinet
{
    public int Id { get; set; }

    public string Cabinet1 { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
