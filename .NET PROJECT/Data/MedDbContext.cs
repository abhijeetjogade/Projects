using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MedLab.Models;
using MedLab.Constants;

namespace MedLab.Data
{
    public partial class MedDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public MedDbContext()
        {
        }

        public MedDbContext(DbContextOptions<MedDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Call base method to configure Identity tables

            // Configure Identity tables
            modelBuilder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.HasKey(l => new { l.LoginProvider, l.ProviderKey });
            });

            modelBuilder.Entity<IdentityUserRole<int>>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
            });

            modelBuilder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            // Configure the UserRole enum conversion
            modelBuilder.Entity<User>()
                .Property(e => e.Role)
                .HasConversion(
                    v => v.ToString(),
                    v => (UserRole)Enum.Parse(typeof(UserRole), v));
        }

        public DbSet<MedLab.Models.Billing> Billing { get; set; } = default!;
        public DbSet<MedLab.Models.Appointment> Appointment { get; set; } = default!;
        public DbSet<MedLab.Models.City> City { get; set; } = default!;
        public DbSet<MedLab.Models.Department> Department { get; set; } = default!;
        public DbSet<MedLab.Models.Prescription> Prescription { get; set; } = default!;
        public DbSet<MedLab.Models.LabAssistant> LabAssistant { get; set; } = default!;
        public DbSet<MedLab.Models.Patient> Patient { get; set; } = default!;
        public DbSet<MedLab.Models.PaymentTransaction> PaymentTransaction { get; set; } = default!;
        public DbSet<MedLab.Models.RazorpayOrder> RazorpayOrder { get; set; } = default!;
        public DbSet<MedLab.Models.Report> Report { get; set; } = default!;
        public DbSet<MedLab.Models.State> State { get; set; } = default!;
        public DbSet<MedLab.Models.RefreshToken> RefreshToken { get; set; } = default!;
        public DbSet<MedLab.Models.Test> Test { get; set; } = default!;
    }
}
