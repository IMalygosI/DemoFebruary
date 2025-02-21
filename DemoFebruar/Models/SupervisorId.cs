using System;
using System.Collections.Generic;

namespace DemoFebruar.Models;

public partial class SupervisorId
{
    public int Id { get; set; }

    public int IdEmployes { get; set; }

    public virtual Employee IdEmployesNavigation { get; set; } = null!;
}
