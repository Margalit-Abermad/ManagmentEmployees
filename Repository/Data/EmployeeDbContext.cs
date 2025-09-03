using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Data;

public partial class EmployeeDbContext : DbContext
{
    public EmployeeDbContext()
    {
    }

    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Employeeproject> Employeeprojects { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Connection string will be provided through dependency injection
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Departmentid).HasName("departments_pkey");

            entity.ToTable("departments");

            entity.Property(e => e.Departmentid).HasColumnName("departmentid");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Employeeid).HasName("employees_pkey");

            entity.ToTable("employees");

            entity.HasIndex(e => e.Email, "employees_email_key").IsUnique();

            entity.Property(e => e.Employeeid).HasColumnName("employeeid");
            entity.Property(e => e.Departmentid).HasColumnName("departmentid");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .HasColumnName("firstname");
            entity.Property(e => e.Hiredate)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("hiredate");
            entity.Property(e => e.Jobtitle)
                .HasMaxLength(100)
                .HasColumnName("jobtitle");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .HasColumnName("lastname");
            entity.Property(e => e.Salary)
                .HasPrecision(10, 2)
                .HasColumnName("salary");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Departmentid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("employees_departmentid_fkey");
        });

        modelBuilder.Entity<Employeeproject>(entity =>
        {
            entity.HasKey(e => new { e.Employeeid, e.Projectid }).HasName("employeeprojects_pkey");

            entity.ToTable("employeeprojects");

            entity.Property(e => e.Employeeid).HasColumnName("employeeid");
            entity.Property(e => e.Projectid).HasColumnName("projectid");
            entity.Property(e => e.Assigneddate)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("assigneddate");

            entity.HasOne(d => d.Employee).WithMany(p => p.Employeeprojects)
                .HasForeignKey(d => d.Employeeid)
                .HasConstraintName("employeeprojects_employeeid_fkey");

            entity.HasOne(d => d.Project).WithMany(p => p.Employeeprojects)
                .HasForeignKey(d => d.Projectid)
                .HasConstraintName("employeeprojects_projectid_fkey");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Projectid).HasName("projects_pkey");

            entity.ToTable("projects");

            entity.Property(e => e.Projectid).HasColumnName("projectid");
            entity.Property(e => e.Enddate).HasColumnName("enddate");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.Startdate).HasColumnName("startdate");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
