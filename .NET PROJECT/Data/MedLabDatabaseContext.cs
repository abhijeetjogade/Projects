using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MedLab.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MedLab.Constants;

namespace MedLab.Data;

public partial class MedLabDatabaseContext : IdentityDbContext<User>
{
    public MedLabDatabaseContext()
    {
    }

    public MedLabDatabaseContext(DbContextOptions<MedLabDatabaseContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MsSqlLocalDb;Initial Catalog=MedLabDatabase;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);

           modelBuilder.Entity<User>()
             .Property(e => e.UserRole) // Assuming 'Role' is the property name in your User class
             .HasConversion(
                 v => v.ToString(), // Convert enum to string for storage
                 v => (Role)Enum.Parse(typeof(Role), v));


        modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.HasKey(l => new { l.LoginProvider, l.ProviderKey });
        });

        modelBuilder.Entity<IdentityUserRole<string>>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RoleId });
        });

        modelBuilder.Entity<IdentityUserToken<string>>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
        });

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    public DbSet<User> Users { get; set; }


    public DbSet<Appointment> Appointment { get; set; } = default!;

    public DbSet<Billing> Billing { get; set; } = default!;

    public DbSet<City> City { get; set; } = default!;

    public DbSet<Department> Department { get; set; } = default!;

    public DbSet<LabAssistant> LabAssistant { get; set; } = default!;

    public DbSet<Patient> Patient { get; set; } = default!;

    public DbSet<Prescription> Prescription { get; set; } = default!;

    public DbSet<Report> Report { get; set; } = default!;

    public DbSet<SampleTracking> SampleTracking { get; set; } = default!;

    public DbSet<State> State { get; set; } = default!;

    public DbSet<Test> Test { get; set; } = default!;
}
