using Microsoft.EntityFrameworkCore;

namespace CQRSDesignPattern.Models;

public partial class CfdbContext : DbContext
{
    public CfdbContext()
    {
    }

    public CfdbContext(DbContextOptions<CfdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<UserCredential> UserCredentials { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasIndex(e => e.DepartmentId, "IX_Employees_DepartmentId");

            entity.Property(e => e.FirstName).HasColumnName("First_Name");
            entity.Property(e => e.LastName).HasColumnName("Last_Name");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees).HasForeignKey(d => d.DepartmentId);
        });

        modelBuilder.Entity<UserCredential>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
