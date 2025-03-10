using System;
using System.Collections.Generic;

namespace DemoFebruar.Models;

public partial class EventsCalendar
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string EventType { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateOnly EventData { get; set; }

    public int ResponsiblePersonId { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<MaterialAssociation> MaterialAssociations { get; set; } = new List<MaterialAssociation>();

    public virtual Employee ResponsiblePerson { get; set; } = null!;

    public virtual ICollection<Employee> DataBirths { get; set; } = new List<Employee>();
}
