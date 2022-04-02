using System;
using System.Collections.Generic;
using KetCRM.Application.Common.Interfaces;
using KetCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KetCRM.Infrastructure.Persistence.Contexts
{
    public partial class ApplicationDbContext :  DbContext, IApplicationDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccessLevel> AccessLevels { get; set; } = null!;
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<FormsOfEducation> FormsOfEducations { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<Person> Persons { get; set; } = null!;
        public virtual DbSet<PersonType> PersonTypes { get; set; } = null!;
        public virtual DbSet<SchoolEducationType> SchoolEducationTypes { get; set; } = null!;
        public virtual DbSet<SchoolType> SchoolTypes { get; set; } = null!;
        public virtual DbSet<Specialization> Specializations { get; set; } = null!;
        public virtual DbSet<StudentInfo> StudentInfos { get; set; } = null!;
        public virtual DbSet<StudentStatus> StudentStatuses { get; set; } = null!;
        public virtual DbSet<StudiedLanguage> StudiedLanguages { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=KetCrmDb.Data;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessLevel>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.Flat).HasMaxLength(10);

                entity.Property(e => e.House).HasMaxLength(10);

                entity.Property(e => e.Region).HasMaxLength(50);

                entity.Property(e => e.Street).HasMaxLength(50);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_Addresses_Persons");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.PersonTeacher)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.PersonTeacherId)
                    .HasConstraintName("FK_Departments_Persons");
            });

            modelBuilder.Entity<FormsOfEducation>(entity =>
            {
                entity.ToTable("FormsOfEducation");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.CourseNumber).HasMaxLength(10);

                entity.Property(e => e.GroupNumber).HasMaxLength(10);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Groups_Departments");

                entity.HasOne(d => d.FormOfEducation)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.FormOfEducationId)
                    .HasConstraintName("FK_Groups_FormsOfEducation");

                entity.HasOne(d => d.PersonTeacher)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.PersonTeacherId)
                    .HasConstraintName("FK_Groups_Persons");

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.SpecializationId)
                    .HasConstraintName("FK_Groups_Specializations");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Comment).HasMaxLength(500);

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.InsuranceNumber).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PassportDate).HasColumnType("date");

                entity.Property(e => e.PassportNumber).HasMaxLength(10);

                entity.Property(e => e.PassportPlace).HasMaxLength(100);

                entity.Property(e => e.PassportSeries).HasMaxLength(10);

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(11);

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.Snils)
                    .HasMaxLength(50)
                    .HasColumnName("SNILS");

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.HasOne(d => d.PersonTypeNavigation)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.PersonType)
                    .HasConstraintName("FK_Persons_PersonTypes");

                entity.HasMany(d => d.Representatives)
                    .WithMany(p => p.Students)
                    .UsingEntity<Dictionary<string, object>>(
                        "Representative",
                        l => l.HasOne<Person>().WithMany().HasForeignKey("RepresentativeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Representatives_Persons1"),
                        r => r.HasOne<Person>().WithMany().HasForeignKey("StudentId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Representatives_Persons"),
                        j =>
                        {
                            j.HasKey("StudentId", "RepresentativeId");

                            j.ToTable("Representatives");
                        });

                entity.HasMany(d => d.Students)
                    .WithMany(p => p.Representatives)
                    .UsingEntity<Dictionary<string, object>>(
                        "Representative",
                        l => l.HasOne<Person>().WithMany().HasForeignKey("StudentId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Representatives_Persons"),
                        r => r.HasOne<Person>().WithMany().HasForeignKey("RepresentativeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Representatives_Persons1"),
                        j =>
                        {
                            j.HasKey("StudentId", "RepresentativeId");

                            j.ToTable("Representatives");
                        });
            });

            modelBuilder.Entity<PersonType>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.AccesLevel)
                    .WithMany(p => p.PersonTypes)
                    .HasForeignKey(d => d.AccesLevelId)
                    .HasConstraintName("FK_PersonTypes_AccessLevels");
            });

            modelBuilder.Entity<SchoolEducationType>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<SchoolType>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Specialization>(entity =>
            {
                entity.Property(e => e.FullName).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(10);
            });

            modelBuilder.Entity<StudentInfo>(entity =>
            {
                entity.ToTable("StudentInfo");

                entity.Property(e => e.GraduatedSchool).HasMaxLength(100);

                entity.Property(e => e.OlimpiadeWinner).HasMaxLength(100);

                entity.Property(e => e.OnAbudget).HasColumnName("OnABudget");

                entity.Property(e => e.PassCardNumber).HasMaxLength(50);

                entity.Property(e => e.SchoolCertificateNumber).HasMaxLength(50);

                entity.Property(e => e.StudentCardNumber).HasMaxLength(50);

                entity.Property(e => e.StudentCerteficateNumber).HasMaxLength(50);

                entity.Property(e => e.StudentRecordBookNumber).HasMaxLength(50);

                entity.Property(e => e.WorkExperience).HasMaxLength(2);

                entity.Property(e => e.YearOfReleaseFromSchool).HasMaxLength(4);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.StudentInfos)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_AdditionalInfo_Groups");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.StudentInfos)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_StudentInfo_Persons");

                entity.HasOne(d => d.SchoolEducationType)
                    .WithMany(p => p.StudentInfos)
                    .HasForeignKey(d => d.SchoolEducationTypeId)
                    .HasConstraintName("FK_StudentInfo_StudentInfo");

                entity.HasOne(d => d.SchoolType)
                    .WithMany(p => p.StudentInfos)
                    .HasForeignKey(d => d.SchoolTypeId)
                    .HasConstraintName("FK_StudentInfo_SchoolTypes");

                entity.HasOne(d => d.StudentStatus)
                    .WithMany(p => p.StudentInfos)
                    .HasForeignKey(d => d.StudentStatusId)
                    .HasConstraintName("FK_StudentInfo_StudentStatuses");

                entity.HasOne(d => d.StudiedLanguage)
                    .WithMany(p => p.StudentInfos)
                    .HasForeignKey(d => d.StudiedLanguageId)
                    .HasConstraintName("FK_StudentInfo_StudiedLanguages");
            });

            modelBuilder.Entity<StudentStatus>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<StudiedLanguage>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
