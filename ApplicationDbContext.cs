using College_EFCore_Linq_Task.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_EFCore_Linq_Task
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(" Data Source=(local); Initial Catalog=CollegeSystem; Integrated Security=true; TrustServerCertificate=True ");
        }
        public DbSet<Hostel> Hostels { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentPhone> StudentPhones { get; set; }
        public DbSet<FacultyMobile> FacultyMobiles { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Exam> Exams { get; set; }
    }
}
