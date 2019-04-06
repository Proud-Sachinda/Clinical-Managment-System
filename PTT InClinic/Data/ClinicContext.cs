using PTT_InClinic.Models;
using Microsoft.EntityFrameworkCore;

namespace PTT_InClinic.Data
{
    public class ClinicContext : DbContext
    {
        public ClinicContext(DbContextOptions<ClinicContext> options) : base(options)
        {
        }

        public DbSet<Practitioner> Practitioners { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
    }
}