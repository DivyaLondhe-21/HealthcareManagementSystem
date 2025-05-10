using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PatientService.Models;

public partial class HealthcareContext : DbContext
{
    public HealthcareContext()
    {
    }

    public HealthcareContext(DbContextOptions<HealthcareContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Patient> Patients { get; set; }

    //public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
