using System;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class TrainingDbContext : DbContext
    {
        private string _connectionString;
        public TrainingDbContext()
        {
            _connectionString = "Server=LAPTOP-VUU5TN3I\\SQLEXPRESS;Database=Assignment2;User Id=admin;Password=admin;TrustServerCertificate=true;\r\n";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseStudent>()
                .HasKey((x) => new { x.StudentId, x.CourseId });

            modelBuilder.Entity<CourseStudent>()
                .HasOne(x => x.Course)
                .WithMany(x => x.CourseStudents);

            modelBuilder.Entity<CourseStudent>()
                .HasOne(x => x.Student)
                .WithMany(x => x.StudentCourses);

            modelBuilder.Entity<Course>()
                .HasOne(x => x.Teacher)
                .WithMany(t => t.TeacherCourses) //Teacher can be associated with multiple courses
                .HasForeignKey(x => x.TeacherId)
                .IsRequired(false);          // Make the relationship nullable

            modelBuilder.Entity<Student>()
           .HasOne(s => s.User)
           .WithOne()
           .HasForeignKey<Student>(s => s.UserId);
            // Make the relationship nullable

            modelBuilder.Entity<Teacher>()
            .HasOne(t => t.User)
            .WithOne()
            .HasForeignKey<Teacher>(t => t.UserId);
            // Make the relationship nullable

            modelBuilder.Entity<Attendance>()
            .HasOne(a => a.Student)
            .WithMany(s => s.StudentAttendances)
            .HasForeignKey(a => a.StudentId);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Course)
                .WithMany(c => c.CourseAttendances)
                .HasForeignKey(a => a.CourseId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
        public DbSet<ClassSchedule> ClassSchedules { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

    }
}
