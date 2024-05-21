using DbTarpinisAtsiskaitymas.Database.InitialData;
using DbTarpinisAtsiskaitymas.Models;
using Microsoft.EntityFrameworkCore;

namespace DbTarpinisAtsiskaitymas.Database
{
    public class UniversityContext : DbContext
    {
        public UniversityContext()
        {
            ConnectionString = "Data Source=DESKTOP-473CTTK\\SQLEXPRESS;Initial Catalog=University;Integrated Security=True;Trust Server Certificate=True";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(ConnectionString);
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(d => d.DepartmentId);
                entity.Property(d => d.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(150);
                entity.HasMany(d => d.DepartmentLectures)
                    .WithOne(dl => dl.Department)
                    .HasForeignKey(dl => dl.DepartmentId);
                entity.HasMany(d => d.Students)
                    .WithOne(s => s.Department)
                    .HasForeignKey(s => s.DepartmentId);
            });
            modelBuilder.Entity<Lecture>(entity =>
            {
                entity.HasKey(l => l.LectureId);
                entity.Property(l => l.LectureName)
                    .IsRequired()
                    .HasMaxLength(150);
                entity.HasMany(l => l.StudentLectures)
                    .WithOne(sl => sl.Lecture)
                    .HasForeignKey(sl => sl.LectureId);
                entity.HasMany(l => l.DepartmentLectures)
                   .WithOne(ld => ld.Lecture)
                   .HasForeignKey(sl => sl.LectureId);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.StudentId);
                entity.Property(s => s.FirstName)
                    .IsRequired()
                    .HasMaxLength(150);
                entity.Property(s => s.LastName)
                    .IsRequired()
                    .HasMaxLength(150);
                entity.Property(s => s.Email)
                    .HasMaxLength(150);
                entity.Property(s => s.Phone)
                    .HasMaxLength(150);
                entity.HasOne(s => s.Department)
                    .WithMany(d => d.Students)
                    .HasForeignKey(s => s.DepartmentId);
                entity.HasMany(s => s.StudentLectures)
                    .WithOne(sl => sl.Student)
                    .HasForeignKey(sl => sl.StudentId);
            });

            modelBuilder.Entity<StudentLecture>(entity =>
            {
                entity.HasKey(sl => new { sl.StudentId, sl.LectureId });
                entity.HasOne(sl => sl.Student)
                    .WithMany(s => s.StudentLectures)
                    .HasForeignKey(sl => sl.StudentId);
                entity.HasOne(sl => sl.Lecture)
                    .WithMany(l => l.StudentLectures)
                    .HasForeignKey(sl => sl.LectureId);
            });

            modelBuilder.Entity<DepartmentLecture>(entity =>
            {
                entity.HasKey(dl => new { dl.DepartmentId, dl.LectureId });
                entity.HasOne(dl => dl.Department)
                    .WithMany(d => d.DepartmentLectures)
                    .HasForeignKey(dl => dl.DepartmentId);
                entity.HasOne(dl => dl.Lecture)
                    .WithMany(l => l.DepartmentLectures)
                    .HasForeignKey(dl => dl.LectureId);
            });

            modelBuilder.Entity<Department>().HasData(DepartmentInitialData.DataSeed);
            modelBuilder.Entity<Lecture>().HasData(LectureInitialData.DataSeed);
            modelBuilder.Entity<Student>().HasData(StudentInitialData.DataSeed);
            modelBuilder.Entity<StudentLecture>().HasData(StudentLectureInitialData.DataSeed);
            modelBuilder.Entity<DepartmentLecture>().HasData(DepartmentLectureInitialData.DataSeed);
        }

        public string ConnectionString { get; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentLecture> StudentLectures { get; set; }
        public DbSet<DepartmentLecture> DepartmentLectures { get; set; }

    }
}
