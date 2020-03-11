using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace LiveCodingEntityFramework
{
    class PostponedContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Structure> Structures { get; set; }
        public DbSet<StructureAppointment> StructureAppointment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=LOCALHOST\SQLEXPRESS; Initial Catalog=LiveCodingEF; Integrated Security=SSPI");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StructureAppointment>()
                .HasKey(sa => new { sa.AppointmentId, sa.StructureId });
            modelBuilder.Entity<StructureAppointment>()
                .HasOne(sa => sa.Appointment)
                .WithMany(a => a.StructureAppointments)
                .HasForeignKey(sa => sa.AppointmentId);
            modelBuilder.Entity<StructureAppointment>()
                .HasOne(sa => sa.Structure)
                .WithMany(s => s.StructureAppointments)
                .HasForeignKey(sa => sa.StructureId);
        }
    }
}
