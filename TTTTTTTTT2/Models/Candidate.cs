using System;
using System.Collections.Generic;

namespace TTTTTTTTT2.Models;

public partial class Candidate
{
    public int Id { get; set; }

    public string Fio { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Position { get; set; } = null!;

    public string Resume { get; set; } = null!;

    public DateOnly SubmissionDate { get; set; }

    public virtual ICollection<HiringPross> HiringProsses { get; set; } = new List<HiringPross>();
}
