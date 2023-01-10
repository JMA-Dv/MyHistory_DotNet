using Microsoft.EntityFrameworkCore;
using MyHistory.Domain.Entities;

namespace MyHistory.Infrastructure.Data
{
    public  class MyHistoryDbContext: DbContext
    {
        public MyHistoryDbContext(DbContextOptions<MyHistoryDbContext> opts): base (opts)
        {
        }

        public DbSet<Medication> Medications { get; set; }
        public DbSet<MedicationAppointment> MedicationAppointments { get; set; }
        public DbSet<Specialist> Specialists { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Appointment> Appointments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("History");
        }


    }
}
