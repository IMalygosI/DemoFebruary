using System;
using System.Collections.Generic;
using DemoFebruar.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoFebruar.Context;

public partial class DimaBaseContext : DbContext
{
    public DimaBaseContext()
    {
    }

    public DimaBaseContext(DbContextOptions<DimaBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AbsenceCalendar> AbsenceCalendars { get; set; }

    public virtual DbSet<AssistantId> AssistantIds { get; set; }

    public virtual DbSet<Cabinet> Cabinets { get; set; }

    public virtual DbSet<Candidate> Candidates { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EventsCalendar> EventsCalendars { get; set; }

    public virtual DbSet<HiringPross> HiringProsses { get; set; }

    public virtual DbSet<JobTitle> JobTitles { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<MaterialAssociation> MaterialAssociations { get; set; }

    public virtual DbSet<SupervisorId> SupervisorIds { get; set; }

    public virtual DbSet<TraningAttendance> TraningAttendances { get; set; }

    public virtual DbSet<TraningCalendar> TraningCalendars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=89.110.53.87:5522;Database=dima_base;Username=dima;password=dima");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AbsenceCalendar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("absence_calendar_pk");

            entity.ToTable("Absence_Calendar", "public_31-01-2025");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.EmployeId).HasColumnName("Employe_ID");
            entity.Property(e => e.EndDate).HasColumnName("End_Date");
            entity.Property(e => e.Reason).HasColumnType("character varying");
            entity.Property(e => e.StartDate).HasColumnName("Start_Date");

            entity.HasOne(d => d.Employe).WithMany(p => p.AbsenceCalendars)
                .HasForeignKey(d => d.EmployeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("absence_calendar_employees_fk");
        });

        modelBuilder.Entity<AssistantId>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("assistant_id_pk");

            entity.ToTable("Assistant_ID", "public_31-01-2025");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdEmployes).HasColumnName("id_employes");

            entity.HasOne(d => d.IdEmployesNavigation).WithMany(p => p.AssistantIds)
                .HasForeignKey(d => d.IdEmployes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("assistant_id_employees_fk");
        });

        modelBuilder.Entity<Cabinet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cabinet_pk");

            entity.ToTable("cabinet", "public_31-01-2025");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Cabinet1)
                .HasColumnType("character varying")
                .HasColumnName("cabinet");
        });

        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("candidate_pk");

            entity.ToTable("Candidate", "public_31-01-2025");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.Email).HasColumnType("character varying");
            entity.Property(e => e.Fio)
                .HasColumnType("character varying")
                .HasColumnName("FIO");
            entity.Property(e => e.Phone).HasColumnType("character varying");
            entity.Property(e => e.Position).HasColumnType("character varying");
            entity.Property(e => e.Resume).HasColumnType("character varying");
            entity.Property(e => e.SubmissionDate).HasColumnName("Submission_Date");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("division_pk");

            entity.ToTable("division", "public_31-01-2025");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasColumnType("character varying");

            entity.HasMany(d => d.IdDivisionOtdels).WithMany(p => p.IdDivisionPotOtdels)
                .UsingEntity<Dictionary<string, object>>(
                    "PotOtdel",
                    r => r.HasOne<Division>().WithMany()
                        .HasForeignKey("IdDivisionOtdel")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("pototdel_division_fk"),
                    l => l.HasOne<Division>().WithMany()
                        .HasForeignKey("IdDivisionPotOtdel")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("pototdel_division_fk_1"),
                    j =>
                    {
                        j.HasKey("IdDivisionOtdel", "IdDivisionPotOtdel").HasName("pototdel_pk");
                        j.ToTable("PotOtdel", "public_31-01-2025");
                        j.IndexerProperty<int>("IdDivisionOtdel").HasColumnName("ID_Division_Otdel");
                        j.IndexerProperty<int>("IdDivisionPotOtdel").HasColumnName("ID_Division_PotOtdel");
                    });

            entity.HasMany(d => d.IdDivisionPotOtdels).WithMany(p => p.IdDivisionOtdels)
                .UsingEntity<Dictionary<string, object>>(
                    "PotOtdel",
                    r => r.HasOne<Division>().WithMany()
                        .HasForeignKey("IdDivisionPotOtdel")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("pototdel_division_fk_1"),
                    l => l.HasOne<Division>().WithMany()
                        .HasForeignKey("IdDivisionOtdel")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("pototdel_division_fk"),
                    j =>
                    {
                        j.HasKey("IdDivisionOtdel", "IdDivisionPotOtdel").HasName("pototdel_pk");
                        j.ToTable("PotOtdel", "public_31-01-2025");
                        j.IndexerProperty<int>("IdDivisionOtdel").HasColumnName("ID_Division_Otdel");
                        j.IndexerProperty<int>("IdDivisionPotOtdel").HasColumnName("ID_Division_PotOtdel");
                    });
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employees_pk");

            entity.ToTable("Employees", "public_31-01-2025");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.AssistantId).HasColumnName("Assistant_ID");
            entity.Property(e => e.BrightDay).HasColumnName("Bright_Day");
            entity.Property(e => e.CorporateEmail)
                .HasMaxLength(50)
                .HasColumnName("Corporate_Email");
            entity.Property(e => e.Fio)
                .HasMaxLength(50)
                .HasColumnName("FIO");
            entity.Property(e => e.Info).HasColumnType("character varying");
            entity.Property(e => e.JobTitle).HasColumnName("Job_Title");
            entity.Property(e => e.PersonalNumber).HasColumnName("Personal_Number");
            entity.Property(e => e.SupervisorId).HasColumnName("Supervisor_ID");
            entity.Property(e => e.WorkPhone).HasColumnName("Work_Phone");

            entity.HasOne(d => d.CabinetNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Cabinet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employees_cabinet_fk");

            entity.HasOne(d => d.JobTitleNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.JobTitle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employees_job_title_fk");

            entity.HasMany(d => d.DataEvents).WithMany(p => p.DataBirths)
                .UsingEntity<Dictionary<string, object>>(
                    "DateCalendar",
                    r => r.HasOne<EventsCalendar>().WithMany()
                        .HasForeignKey("DataEvent")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("datecalendar_events_calendar_fk"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("DataBirth")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("datecalendar_employees_fk"),
                    j =>
                    {
                        j.HasKey("DataBirth", "DataEvent").HasName("datecalendar_pk");
                        j.ToTable("DateCalendar", "public_31-01-2025");
                    });

            entity.HasMany(d => d.IdOtdels).WithMany(p => p.IdEmployes)
                .UsingEntity<Dictionary<string, object>>(
                    "StructuralSeparation",
                    r => r.HasOne<Division>().WithMany()
                        .HasForeignKey("IdOtdel")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("structural_separation_division_fk"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("IdEmployes")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("structural_separation_employees_fk"),
                    j =>
                    {
                        j.HasKey("IdEmployes", "IdOtdel").HasName("structural_separation_pk");
                        j.ToTable("Structural_Separation", "public_31-01-2025");
                        j.IndexerProperty<int>("IdEmployes").HasColumnName("id_employes");
                        j.IndexerProperty<int>("IdOtdel").HasColumnName("id_otdel");
                    });
        });

        modelBuilder.Entity<EventsCalendar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("events_calendar_pk");

            entity.ToTable("Events_Calendar", "public_31-01-2025");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.EventData).HasColumnName("Event_Data");
            entity.Property(e => e.EventType)
                .HasColumnType("character varying")
                .HasColumnName("Event_Type");
            entity.Property(e => e.Name).HasColumnType("character varying");
            entity.Property(e => e.ResponsiblePersonId).HasColumnName("Responsible_Person_ID");
            entity.Property(e => e.Status).HasColumnType("character varying");

            entity.HasOne(d => d.ResponsiblePerson).WithMany(p => p.EventsCalendars)
                .HasForeignKey(d => d.ResponsiblePersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("events_calendar_employees_fk");
        });

        modelBuilder.Entity<HiringPross>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.EmployeId, e.CandidateId }).HasName("hiring_prosses_pk");

            entity.ToTable("Hiring_Prosses", "public_31-01-2025");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EmployeId).HasColumnName("Employe_ID");
            entity.Property(e => e.CandidateId).HasColumnName("Candidate_ID");

            entity.HasOne(d => d.Candidate).WithMany(p => p.HiringProsses)
                .HasForeignKey(d => d.CandidateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hiring_prosses_candidate_fk");

            entity.HasOne(d => d.Employe).WithMany(p => p.HiringProsses)
                .HasForeignKey(d => d.EmployeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hiring_prosses_employees_fk");
        });

        modelBuilder.Entity<JobTitle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("job_title_pk");

            entity.ToTable("Job_Title", "public_31-01-2025");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("materials_pk");

            entity.ToTable("Materials", "public_31-01-2025");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.ApprovalDate).HasColumnName("Approval_Date");
            entity.Property(e => e.AuthorId).HasColumnName("Author_ID");
            entity.Property(e => e.ModificationsDate).HasColumnName("Modifications_Date");
            entity.Property(e => e.Name).HasColumnType("character varying");
            entity.Property(e => e.Region).HasColumnType("character varying");
            entity.Property(e => e.Status).HasColumnType("character varying");
            entity.Property(e => e.Type).HasColumnType("character varying");

            entity.HasOne(d => d.Author).WithMany(p => p.Materials)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("materials_employees_fk");
        });

        modelBuilder.Entity<MaterialAssociation>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.MaterialId, e.TrainingId, e.EventId }).HasName("material_association_pk");

            entity.ToTable("Material_Association", "public_31-01-2025");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MaterialId).HasColumnName("Material_ID");
            entity.Property(e => e.TrainingId).HasColumnName("Training_ID");
            entity.Property(e => e.EventId).HasColumnName("Event_ID");

            entity.HasOne(d => d.Event).WithMany(p => p.MaterialAssociations)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("material_association_events_calendar_fk");

            entity.HasOne(d => d.Material).WithMany(p => p.MaterialAssociations)
                .HasForeignKey(d => d.MaterialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("material_association_materials_fk");

            entity.HasOne(d => d.Training).WithMany(p => p.MaterialAssociations)
                .HasForeignKey(d => d.TrainingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("material_association_traning_calendar_fk");
        });

        modelBuilder.Entity<SupervisorId>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("supervisor_id_pk");

            entity.ToTable("Supervisor_ID", "public_31-01-2025");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IdEmployes).HasColumnName("ID_Employes");

            entity.HasOne(d => d.IdEmployesNavigation).WithMany(p => p.SupervisorIds)
                .HasForeignKey(d => d.IdEmployes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("supervisor_id_employees_fk");
        });

        modelBuilder.Entity<TraningAttendance>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.TrainingId, e.EmployeId }).HasName("traning_attendance_pk");

            entity.ToTable("Traning_Attendance", "public_31-01-2025");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TrainingId).HasColumnName("Training_ID");
            entity.Property(e => e.EmployeId).HasColumnName("Employe_ID");

            entity.HasOne(d => d.Employe).WithMany(p => p.TraningAttendances)
                .HasForeignKey(d => d.EmployeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("traning_attendance_employees_fk");

            entity.HasOne(d => d.Training).WithMany(p => p.TraningAttendances)
                .HasForeignKey(d => d.TrainingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("traning_attendance_traning_calendar_fk");
        });

        modelBuilder.Entity<TraningCalendar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("traning_calendar_pk");

            entity.ToTable("Traning_Calendar", "public_31-01-2025");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Classifical).HasMaxLength(250);
            entity.Property(e => e.Description).HasColumnType("character varying");
            entity.Property(e => e.Name).HasColumnType("character varying");
            entity.Property(e => e.TraningData).HasColumnName("Traning_Data");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
