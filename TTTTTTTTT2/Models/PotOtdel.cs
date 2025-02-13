using System;
using System.Collections.Generic;

namespace TTTTTTTTT2.Models;

public partial class PotOtdel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? IdStructal { get; set; }

    public virtual StructuralSeparation? IdStructalNavigation { get; set; }
}
