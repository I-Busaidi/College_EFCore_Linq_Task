using College_EFCore_Linq_Task.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_EFCore_Linq_Task.Repositories
{
    public class CourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses.Include(c => c.StudentsInCourse)
                                   .ThenInclude(s => s.Student)
                                   .ThenInclude(f => f.Teacher)
                                   .ToList();
        }

        public Course GetCourseById(int Course_ID)
        {
            return _context.Courses.Where(c => c.CourseID == Course_ID)
                                   .Include(s => s.StudentsInCourse)
                                   .ThenInclude(s => s.Student)
                                   .ThenInclude(t => t.Teacher)
                                   .SingleOrDefault();
        }

        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }

        public void DeleteCourse(int Course_Id)
        {
            var course = GetCourseById(Course_Id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Course> GetCoursesByDept(int DeptId)
        {
            return _context.Courses.Where(c => c.Dept_Id == DeptId)
                                   .ToList();
        }

        public IEnumerable<Course> GetCoursesWithDuration(decimal duration)
        {
            return _context.Courses.Where(c => c.Duration == duration)
                                   .ToList();
        }

        public IEnumerable<Course> PaginateCourses(int page, int pageSize)
        {
            return _context.Courses.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
