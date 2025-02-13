﻿using System;
using System.Collections.Generic;

namespace TTTTTTTTT2.Models;

public partial class JobTitle
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
