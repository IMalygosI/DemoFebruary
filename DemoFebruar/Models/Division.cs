using System;
using System.Collections.Generic;

namespace DemoFebruar.Models;

public partial class Division
{
    public int Id { get; set; }

    public int IdPototdel { get; set; }

    public int IdStructuralSeparation { get; set; }

    public virtual PotOtdel IdPototdelNavigation { get; set; } = null!;

    public virtual StructuralSeparation IdStructuralSeparationNavigation { get; set; } = null!;
}
