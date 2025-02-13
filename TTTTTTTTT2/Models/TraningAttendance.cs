using System;
using System.Collections.Generic;

namespace TTTTTTTTT2.Models;

public partial class TraningAttendance
{
    public int EmployeId { get; set; }

    public int TrainingId { get; set; }

    public int Id { get; set; }

    public virtual Employee Employe { get; set; } = null!;

    public virtual TraningCalendar Training { get; set; } = null!;
}
