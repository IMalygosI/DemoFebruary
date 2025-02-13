using System;
using System.Collections.Generic;

namespace TTTTTTTTT2.Models;

public partial class AbsenceCalendar
{
    public int Id { get; set; }

    public int EmployeId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string Reason { get; set; } = null!;

    public virtual Employee Employe { get; set; } = null!;
}
