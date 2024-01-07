using Managment.Models;
using Microsoft.EntityFrameworkCore;

namespace Managment.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<MarksDetail> MarksDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, StudentName = "Ram", Section = "Class A" },
                new Student { StudentId = 2, StudentName = "Seetha", Section = "Class B" },
                new Student { StudentId = 3, StudentName = "John", Section = "Class C" });

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { TeacherId = 1, TeacherName = "Ramesh" },
                new Teacher { TeacherId = 2, TeacherName = "Rahul" },
                new Teacher { TeacherId = 3, TeacherName = "Akhil" });
            modelBuilder.Entity<MarksDetail>().HasData(
                new MarksDetail { MarksId = 1, /*StudentId = 1, TeacherId = 1,*/ Subject = "Math", MarksObtained = 90 },
                new MarksDetail { MarksId = 2, /*StudentId = 2, TeacherId = 2,*/ Subject = "Science", MarksObtained = 85 },
                new MarksDetail { MarksId = 3, /*StudentId = 3, TeacherId = 3,*/ Subject = "History", MarksObtained = 75 });


            //modelBuilder.Entity<MarksDetail>()
            //    .HasOne(md => md.Student)
            //    .WithMany(s => s.MarksDetails)
            //    .HasForeignKey(md => md.StudentId);

            //    //modelBuilder.Entity<MarksDetail>()
            //    //    .HasOne(md => md.Teacher)
            //    //    .WithMany(t => t.MarksDetails)
            //    //    .HasForeignKey(md => md.TeacherId);
            //    //}
        }
    }
}
