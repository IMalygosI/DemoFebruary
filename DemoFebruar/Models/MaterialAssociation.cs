using System;
using System.Collections.Generic;

namespace DemoFebruar.Models;

public partial class MaterialAssociation
{
    public int Id { get; set; }

    public int MaterialId { get; set; }

    public int TrainingId { get; set; }

    public int EventId { get; set; }

    public virtual EventsCalendar Event { get; set; } = null!;

    public virtual Material Material { get; set; } = null!;

    public virtual TraningCalendar Training { get; set; } = null!;
}
