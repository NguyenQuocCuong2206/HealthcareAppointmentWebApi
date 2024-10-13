﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PraticeWebApi1.Data;

#nullable disable

namespace HealthcareAppointment.Data.Migrations
{
    [DbContext(typeof(HealthcareDbContext))]
    partial class HealthcareDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PraticeWebApi1.Models.Appointments", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8994847f-592a-404b-810f-35e9cd453a94"),
                            Date = new DateTime(2024, 10, 11, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = new Guid("52de789c-6155-420e-ad0a-a0e4fd055d6f"),
                            PatientId = new Guid("b3eb445a-e851-42f0-a2e1-2fe8b77df65e"),
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("c91a0f9e-e569-4749-ab52-d3d74f7792f7"),
                            Date = new DateTime(2024, 10, 12, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = new Guid("bd352e82-edc4-4f3f-bc27-f183d8e3fdcf"),
                            PatientId = new Guid("b3eb445a-e851-42f0-a2e1-2fe8b77df65e"),
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("214d71c2-bf06-4597-82ad-1cd8b43cad18"),
                            Date = new DateTime(2024, 10, 13, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = new Guid("6f5b8cd3-1ac7-4825-a472-dce165de3ee8"),
                            PatientId = new Guid("b3eb445a-e851-42f0-a2e1-2fe8b77df65e"),
                            Status = 2
                        },
                        new
                        {
                            Id = new Guid("39276b54-2b79-4322-b261-4ef733e3089d"),
                            Date = new DateTime(2024, 10, 14, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = new Guid("bd352e82-edc4-4f3f-bc27-f183d8e3fdcf"),
                            PatientId = new Guid("a78a6edf-5126-415c-bb85-5068325ad848"),
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("0bae4774-f889-410d-b3e4-9feef14c67d7"),
                            Date = new DateTime(2024, 10, 15, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = new Guid("6f5b8cd3-1ac7-4825-a472-dce165de3ee8"),
                            PatientId = new Guid("a78a6edf-5126-415c-bb85-5068325ad848"),
                            Status = 3
                        });
                });

            modelBuilder.Entity("PraticeWebApi1.Models.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b3eb445a-e851-42f0-a2e1-2fe8b77df65e"),
                            DateOfBirth = new DateOnly(1980, 1, 1),
                            Email = "johndoe@gmail.com",
                            Name = "John Doe",
                            Password = "password",
                            Role = 1,
                            Specialization = ""
                        },
                        new
                        {
                            Id = new Guid("a78a6edf-5126-415c-bb85-5068325ad848"),
                            DateOfBirth = new DateOnly(1985, 2, 1),
                            Email = "janedoe@gmail.com",
                            Name = "Jane Doe",
                            Password = "password",
                            Role = 1,
                            Specialization = ""
                        },
                        new
                        {
                            Id = new Guid("52de789c-6155-420e-ad0a-a0e4fd055d6f"),
                            DateOfBirth = new DateOnly(1975, 3, 1),
                            Email = "drsmith@gmail.com",
                            Name = "Dr. Smith",
                            Password = "password",
                            Role = 0,
                            Specialization = "Cardiology"
                        },
                        new
                        {
                            Id = new Guid("6f5b8cd3-1ac7-4825-a472-dce165de3ee8"),
                            DateOfBirth = new DateOnly(1980, 4, 1),
                            Email = "drbrown@gmail.com",
                            Name = "Dr. Brown",
                            Password = "password",
                            Role = 0,
                            Specialization = "Neurology"
                        },
                        new
                        {
                            Id = new Guid("bd352e82-edc4-4f3f-bc27-f183d8e3fdcf"),
                            DateOfBirth = new DateOnly(1985, 5, 1),
                            Email = "dradams@gmail.com",
                            Name = "Dr. Adams",
                            Password = "password",
                            Role = 0,
                            Specialization = "Pediatrics"
                        });
                });

            modelBuilder.Entity("PraticeWebApi1.Models.Appointments", b =>
                {
                    b.HasOne("PraticeWebApi1.Models.Users", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PraticeWebApi1.Models.Users", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });
#pragma warning restore 612, 618
        }
    }
}
