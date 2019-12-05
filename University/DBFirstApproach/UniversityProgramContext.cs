using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBFirstApproach
{
    public partial class UniversityProgramContext : DbContext
    {
        public UniversityProgramContext()
        {
        }

        public UniversityProgramContext(DbContextOptions<UniversityProgramContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Professeur> Professeurs { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentsSubjects> StudentsSubjects { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-59C4S0U9;Database=UniversityProgram;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Professeur>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(35);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.FacultyNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(35);
            });

            modelBuilder.Entity<StudentsSubjects>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.SubjectId })
                    .HasName("PK__Students__A80491A34322637B");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentsSubjects)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentsS__Stude__3E52440B");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.StudentsSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentsS__Subje__3F466844");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.HasOne(d => d.Professeur)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.ProfesseurId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Subjects__Profes__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
