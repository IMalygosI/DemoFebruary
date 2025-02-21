﻿using System;
using System.Collections.Generic;

namespace DemoFebruar.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Fio { get; set; } = null!;

    public int StructuralSeparation { get; set; }

    public int JobTitle { get; set; }

    public string WorkPhone { get; set; } = null!;

    public string? PersonalNumber { get; set; }

    public int Cabinet { get; set; }

    public string? CorporateEmail { get; set; }

    public int? AssistantId { get; set; }

    public int? SupervisorId { get; set; }

    public string? Info { get; set; }

    public DateOnly BrightDay { get; set; }

    public virtual ICollection<AbsenceCalendar> AbsenceCalendars { get; set; } = new List<AbsenceCalendar>();

    public virtual Employee? Assistant { get; set; }

    public virtual Cabinet CabinetNavigation { get; set; } = null!;

    public virtual ICollection<EventsCalendar> EventsCalendars { get; set; } = new List<EventsCalendar>();

    public virtual ICollection<HiringPross> HiringProsses { get; set; } = new List<HiringPross>();

    public virtual ICollection<Employee> InverseAssistant { get; set; } = new List<Employee>();

    public virtual ICollection<Employee> InverseSupervisor { get; set; } = new List<Employee>();

    public virtual JobTitle JobTitleNavigation { get; set; } = null!;

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();

    public virtual StructuralSeparation StructuralSeparationNavigation { get; set; } = null!;

    public virtual Employee? Supervisor { get; set; }

    public virtual ICollection<TraningAttendance> TraningAttendances { get; set; } = new List<TraningAttendance>();
}
