using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace jobconnect.Models;

public partial class RecruitmentManagementContext : DbContext
{
    public RecruitmentManagementContext()
    {
    }

    public RecruitmentManagementContext(DbContextOptions<RecruitmentManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<ApplicationStatus> ApplicationStatuses { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Field> Fields { get; set; }

    public virtual DbSet<Interview> Interviews { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobType> JobTypes { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Profession> Professions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-D5N06VCG;Initial Catalog=RecruitmentManagement;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.ApplicationId).HasName("PK__Applicat__C93A4F792319A25E");

            entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");
            entity.Property(e => e.ApplicationDate).HasColumnType("datetime");
            entity.Property(e => e.Cv).HasColumnName("CV");
            entity.Property(e => e.JobId).HasColumnName("JobID");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Job).WithMany(p => p.Applications)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK__Applicati__JobID__66603565");

            entity.HasOne(d => d.Status).WithMany(p => p.Applications)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__Applicati__Statu__68487DD7");

            entity.HasOne(d => d.User).WithMany(p => p.Applications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Applicati__UserI__6754599E");
        });

        modelBuilder.Entity<ApplicationStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Applicat__C8EE20430E0F1444");

            entity.ToTable("ApplicationStatus");

            entity.HasIndex(e => e.StatusName, "UQ__Applicat__05E7698A227D0D7F").IsUnique();

            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.StatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__Companie__2D971C4C633334A9");

            entity.HasIndex(e => e.EmailCompanies, "UQ__Companie__B805C4A49331EDEE").IsUnique();

            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CompanyName).HasMaxLength(255);
            entity.Property(e => e.EmailCompanies).HasMaxLength(255);
            entity.Property(e => e.FieldId).HasColumnName("FieldID");
            entity.Property(e => e.Phone).HasMaxLength(11);

            entity.HasOne(d => d.Field).WithMany(p => p.Companies)
                .HasForeignKey(d => d.FieldId)
                .HasConstraintName("FK__Companies__Field__17036CC0");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF6F9A99058");

            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.FeedbackDate).HasColumnType("datetime");
            entity.Property(e => e.InterviewId).HasColumnName("InterviewID");

            entity.HasOne(d => d.Interview).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.InterviewId)
                .HasConstraintName("FK__Feedbacks__Inter__6EF57B66");
        });

        modelBuilder.Entity<Field>(entity =>
        {
            entity.HasKey(e => e.FieldId).HasName("PK__Fields__C8B6FF274CC170CA");

            entity.HasIndex(e => e.FieldName, "UQ__Fields__A88707A67B87F19A").IsUnique();

            entity.Property(e => e.FieldId).HasColumnName("FieldID");
            entity.Property(e => e.FieldName).HasMaxLength(255);
        });

        modelBuilder.Entity<Interview>(entity =>
        {
            entity.HasKey(e => e.InterviewId).HasName("PK__Intervie__C97C58321209B23E");

            entity.Property(e => e.InterviewId).HasColumnName("InterviewID");
            entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");
            entity.Property(e => e.InterviewDate).HasColumnType("datetime");
            entity.Property(e => e.InterviewLocation).HasMaxLength(255);
            entity.Property(e => e.InterviewType).HasMaxLength(50);

            entity.HasOne(d => d.Application).WithMany(p => p.Interviews)
                .HasForeignKey(d => d.ApplicationId)
                .HasConstraintName("FK__Interview__Appli__6B24EA82");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("PK__Jobs__056690E288526EB7");

            entity.Property(e => e.JobId).HasColumnName("JobID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.ExperienceLevel).HasMaxLength(50);
            entity.Property(e => e.JobTypeId).HasColumnName("JobTypeID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.PostedDate).HasColumnType("datetime");
            entity.Property(e => e.ProfessionId).HasColumnName("ProfessionID");
            entity.Property(e => e.SalaryRange).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Company).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__Jobs__CompanyID__628FA481");

            entity.HasOne(d => d.JobType).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.JobTypeId)
                .HasConstraintName("FK__Jobs__JobTypeID__6383C8BA");

            entity.HasOne(d => d.Location).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK_Jobs_Locations");

            entity.HasOne(d => d.Profession).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.ProfessionId)
                .HasConstraintName("FK__Jobs__Profession__1AD3FDA4");
        });

        modelBuilder.Entity<JobType>(entity =>
        {
            entity.HasKey(e => e.JobTypeId).HasName("PK__JobTypes__E1F4624D00517FAF");

            entity.HasIndex(e => e.JobTypeName, "UQ__JobTypes__2C951EA8F78FD137").IsUnique();

            entity.Property(e => e.JobTypeId).HasColumnName("JobTypeID");
            entity.Property(e => e.JobTypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA47774A6D3E2");

            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.LocationName).HasMaxLength(255);
        });

        modelBuilder.Entity<Profession>(entity =>
        {
            entity.HasKey(e => e.ProfessionId).HasName("PK__Professi__3F309E1F7A08370C");

            entity.HasIndex(e => e.ProfessionName, "UQ__Professi__704E62FB9BBFA128").IsUnique();

            entity.Property(e => e.ProfessionId).HasColumnName("ProfessionID");
            entity.Property(e => e.ProfessionName).HasMaxLength(255);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3AC41ACACA");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B61609449FD77").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC2029234F");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E4615D8EE7").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534E7FD123C").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.AvatarUrl).HasColumnName("AvatarURL");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Username).HasMaxLength(100);

            entity.HasOne(d => d.Company).WithMany(p => p.Users)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__Users__CompanyID__5FB337D6");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__RoleID__5EBF139D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
