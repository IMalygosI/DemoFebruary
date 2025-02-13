using System;
using System.Collections.Generic;

namespace TTTTTTTTT2.Models;

public partial class StructuralSeparation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? HeadOfDepartment { get; set; }

    public int? IdPotOtdel { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Employee? HeadOfDepartmentNavigation { get; set; }

    public virtual ICollection<PotOtdel> PotOtdels { get; set; } = new List<PotOtdel>();
}
