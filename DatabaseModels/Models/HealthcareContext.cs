using DatabaseModels.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseModels.Data
{
    public class HealthcareContext : DbContext
    {
        public HealthcareContext(DbContextOptions<HealthcareContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
