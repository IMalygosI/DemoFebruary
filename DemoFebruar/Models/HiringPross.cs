using System;
using System.Collections.Generic;

namespace DemoFebruar.Models;

public partial class HiringPross
{
    public int Id { get; set; }

    public int EmployeId { get; set; }

    public int CandidateId { get; set; }

    public virtual Candidate Candidate { get; set; } = null!;

    public virtual Employee Employe { get; set; } = null!;
}
