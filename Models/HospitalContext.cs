

using Microsoft.EntityFrameworkCore;

namespace WebFinal.Models
{
    public class HospitalContext : DbContext
    {

        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
{

    base.OnModelCreating(modelBuilder);
}


        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Nurse> Nurses { get; set;}

        public DbSet<Appointment> Appointments { get; set; }
    }
}