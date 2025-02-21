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

    public virtual DbSet<Cabinet> Cabinets { get; set; }

    public virtual DbSet<Candidate> Candidates { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EventsCalendar> EventsCalendars { get; set; }

    public virtual DbSet<HiringPross> HiringProsses { get; set; }

    public virtual DbSet<JobTitle> JobTitles { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<MaterialAssociation> MaterialAssociations { get; set; }

    public virtual DbSet<PotOtdel> PotOtdels { get; set; }

    public virtual DbSet<StructuralSeparation> StructuralSeparations { get; set; }

    public virtual DbSet<Subdivision> Subdivisions { get; set; }

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
            entity.HasKey(e => new { e.Id, e.IdPototdel, e.IdStructuralSeparation }).HasName("division_pk");

            entity.ToTable("division", "public_31-01-2025");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdPototdel).HasColumnName("id_pototdel");
            entity.Property(e => e.IdStructuralSeparation).HasColumnName("id_structural_separation");

            entity.HasOne(d => d.IdPototdelNavigation).WithMany(p => p.Divisions)
                .HasForeignKey(d => d.IdPototdel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("division_pototdel_fk");

            entity.HasOne(d => d.IdStructuralSeparationNavigation).WithMany(p => p.Divisions)
                .HasForeignKey(d => d.IdStructuralSeparation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("division_structural_separation_fk");
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
            entity.Property(e => e.StructuralSeparation).HasColumnName("Structural_Separation");
            entity.Property(e => e.SupervisorId).HasColumnName("Supervisor_ID");
            entity.Property(e => e.WorkPhone).HasColumnName("Work_Phone");

            entity.HasOne(d => d.Assistant).WithMany(p => p.InverseAssistant)
                .HasForeignKey(d => d.AssistantId)
                .HasConstraintName("employees_employees_fk");

            entity.HasOne(d => d.CabinetNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Cabinet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employees_cabinet_fk");

            entity.HasOne(d => d.JobTitleNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.JobTitle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employees_job_title_fk");

            entity.HasOne(d => d.StructuralSeparationNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.StructuralSeparation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employees_structural_separation_fk");

            entity.HasOne(d => d.Supervisor).WithMany(p => p.InverseSupervisor)
                .HasForeignKey(d => d.SupervisorId)
                .HasConstraintName("employees_employees_fk_1");
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

        modelBuilder.Entity<PotOtdel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pototdel_pk");

            entity.ToTable("PotOtdel", "public_31-01-2025");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasColumnType("character varying");
        });

        modelBuilder.Entity<StructuralSeparation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("structural_separation_pk");

            entity.ToTable("Structural_Separation", "public_31-01-2025");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Subdivision>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("subdivisions_pk");

            entity.ToTable("Subdivisions", "public_31-01-2025");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.StructuralSeparationId).HasColumnName("Structural_Separation_ID");
            entity.Property(e => e.SubdivisionsName)
                .HasColumnType("character varying")
                .HasColumnName("Subdivisions_Name");

            entity.HasOne(d => d.StructuralSeparation).WithMany(p => p.Subdivisions)
                .HasForeignKey(d => d.StructuralSeparationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("subdivisions_structural_separation_fk");
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
