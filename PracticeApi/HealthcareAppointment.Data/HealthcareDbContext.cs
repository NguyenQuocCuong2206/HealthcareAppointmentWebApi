using Microsoft.EntityFrameworkCore;
using PraticeWebApi1.Models;

namespace PraticeWebApi1.Data
{
    public class HealthcareDbContext : DbContext
    {
        public HealthcareDbContext(DbContextOptions<HealthcareDbContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Appointments> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Appointments>()
                .HasOne(a => a.Patient)
                .WithMany()
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointments>()
                .HasOne(a => a.Doctor)
                .WithMany()
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<Users>().HasData(
                new Users { Id = new Guid("B3EB445A-E851-42F0-A2E1-2FE8B77DF65E"), Name = "John Doe", Email = "johndoe@gmail.com", DateOfBirth = new DateOnly(1980, 1, 1), Password = "password", Role = EnumRole.Patient },
                new Users { Id = new Guid("A78A6EDF-5126-415C-BB85-5068325AD848"), Name = "Jane Doe", Email = "janedoe@gmail.com", DateOfBirth = new DateOnly(1985, 2, 1), Password = "password", Role = EnumRole.Patient },
                new Users { Id = new Guid("52DE789C-6155-420E-AD0A-A0E4FD055D6F"), Name = "Dr. Smith", Email = "drsmith@gmail.com", DateOfBirth = new DateOnly(1975, 3, 1), Password = "password", Role = EnumRole.Doctor, Specialization = "Cardiology" },
                new Users { Id = new Guid("6F5B8CD3-1AC7-4825-A472-DCE165DE3EE8"), Name = "Dr. Brown", Email = "drbrown@gmail.com", DateOfBirth = new DateOnly(1980, 4, 1), Password = "password", Role = EnumRole.Doctor, Specialization = "Neurology" },
                new Users { Id = new Guid("BD352E82-EDC4-4F3F-BC27-F183D8E3FDCF"), Name = "Dr. Adams", Email = "dradams@gmail.com", DateOfBirth = new DateOnly(1985, 5, 1), Password = "password", Role = EnumRole.Doctor, Specialization = "Pediatrics" }
            );

            modelBuilder.Entity<Appointments>().HasData(
            new Appointments { Id = Guid.NewGuid(), PatientId = new Guid("B3EB445A-E851-42F0-A2E1-2FE8B77DF65E"), DoctorId = new Guid("52DE789C-6155-420E-AD0A-A0E4FD055D6F"), Date = new DateTime(2024, 10, 11, 9, 0, 0), Status = EnumStatus.Scheduled },
            new Appointments { Id = Guid.NewGuid(), PatientId = new Guid("B3EB445A-E851-42F0-A2E1-2FE8B77DF65E"), DoctorId = new Guid("BD352E82-EDC4-4F3F-BC27-F183D8E3FDCF"), Date = new DateTime(2024, 10, 12, 10, 0, 0), Status = EnumStatus.Scheduled },
            new Appointments { Id = Guid.NewGuid(), PatientId = new Guid("B3EB445A-E851-42F0-A2E1-2FE8B77DF65E"), DoctorId = new Guid("6F5B8CD3-1AC7-4825-A472-DCE165DE3EE8"), Date = new DateTime(2024, 10, 13, 11, 0, 0), Status = EnumStatus.Completed },
            new Appointments { Id = Guid.NewGuid(), PatientId = new Guid("A78A6EDF-5126-415C-BB85-5068325AD848"), DoctorId = new Guid("BD352E82-EDC4-4F3F-BC27-F183D8E3FDCF"), Date = new DateTime(2024, 10, 14, 12, 0, 0), Status = EnumStatus.Scheduled },
            new Appointments { Id = Guid.NewGuid(), PatientId = new Guid("A78A6EDF-5126-415C-BB85-5068325AD848"), DoctorId = new Guid("6F5B8CD3-1AC7-4825-A472-DCE165DE3EE8"), Date = new DateTime(2024, 10, 15, 13, 0, 0), Status = EnumStatus.Cancelled }
        );
        }
    }
}
