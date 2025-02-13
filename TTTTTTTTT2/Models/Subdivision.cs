using System;
using System.Collections.Generic;

namespace TTTTTTTTT2.Models;

public partial class Subdivision
{
    public int Id { get; set; }

    public string SubdivisionsName { get; set; } = null!;

    public int StructuralSeparationId { get; set; }

    public virtual StructuralSeparation StructuralSeparation { get; set; } = null!;
}
