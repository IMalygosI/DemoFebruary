using System;
using System.Collections.Generic;

namespace DemoFebruar.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Fio { get; set; } = null!;

    public int JobTitle { get; set; }

    public string WorkPhone { get; set; } = null!;

    public string? PersonalNumber { get; set; }

    public int Cabinet { get; set; }

    public string? CorporateEmail { get; set; }

    public int? AssistantId { get; set; }

    public int? SupervisorId { get; set; }

    public string? Info { get; set; }

    public DateOnly BrightDay { get; set; }




    public string GetDay => $"{BrightDay.Day} {GetMonth()}"; // День рождения

    private string GetMonth()
    {
        string month = "";

        switch (BrightDay.Month)
        {
            case 1:
                month = "Январь";
                break;
            case 2:
                month = "Февраль";
                break;
            case 3:
                month = "Март";
                break;
            case 4:
                month = "Апрель";
                break;
            case 5:
                month = "Май";
                break;
            case 6:
                month = "Июнь";
                break;
            case 7:
                month = "Июль";
                break;
            case 8:
                month = "Август";
                break;
            case 9:
                month = "Сентябрь";
                break;
            case 10:
                month = "Октябрь";
                break;
            case 11:
                month = "Ноябрь";
                break;
            case 12:
                month = "Декабрь";
                break;
        }
        return month;
    }




    public virtual ICollection<AbsenceCalendar> AbsenceCalendars { get; set; } = new List<AbsenceCalendar>();

    public virtual ICollection<AssistantId> AssistantIds { get; set; } = new List<AssistantId>();

    public virtual Cabinet CabinetNavigation { get; set; } = null!;

    public virtual ICollection<EventsCalendar> EventsCalendars { get; set; } = new List<EventsCalendar>();

    public virtual ICollection<HiringPross> HiringProsses { get; set; } = new List<HiringPross>();

    public virtual JobTitle JobTitleNavigation { get; set; } = null!;

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();

    public virtual ICollection<SupervisorId> SupervisorIds { get; set; } = new List<SupervisorId>();

    public virtual ICollection<TraningAttendance> TraningAttendances { get; set; } = new List<TraningAttendance>();

    public virtual ICollection<EventsCalendar> DataEvents { get; set; } = new List<EventsCalendar>();

    public virtual ICollection<Division> IdOtdels { get; set; } = new List<Division>();
}
