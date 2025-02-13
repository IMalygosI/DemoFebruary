using System;
using System.Collections.Generic;

namespace TTTTTTTTT2.Models;

public partial class TraningCalendar
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateOnly TraningData { get; set; }

    public string Classifical { get; set; } = null!;

    public virtual ICollection<MaterialAssociation> MaterialAssociations { get; set; } = new List<MaterialAssociation>();

    public virtual ICollection<TraningAttendance> TraningAttendances { get; set; } = new List<TraningAttendance>();
}
