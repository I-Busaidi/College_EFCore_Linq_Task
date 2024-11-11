using College_EFCore_Linq_Task.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_EFCore_Linq_Task.Repositories
{
    public class StudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.Include(sp => sp.StudentPhones)
                                    .Include(h => h.Hostel)
                                    .Include(sc => sc.StudentCourses)
                                    .ThenInclude(c => c.Course)
                                    .ThenInclude(d => d.Department)
                                    .ThenInclude(e => e.Exams)
                                    .ToList();
        }

        public Student GetStudentById(int studentId)
        {
            return _context.Students.Include(sp => sp.StudentPhones)
                                    .Include(h => h.Hostel)
                                    .Include(sc => sc.StudentCourses)
                                    .ThenInclude(c => c.Course)
                                    .ThenInclude(d => d.Department)
                                    .ThenInclude(e => e.Exams)
                                    .Where(st => st.SID == studentId)
                                    .SingleOrDefault();
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(int studentId)
        {
            var student = GetStudentById(studentId);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Student> GetStudentByCourse(int CourseID)
        {
            return _context.StudentCourses.Where(c => c.Course_id == CourseID)
                                          .Include(s => s.Student)
                                          .ThenInclude (sp => sp.StudentPhones)
                                          .Select(c => c.Student)
                                          .ToList();
        }

        public IEnumerable<Student> GetStudentsInHostel(int HostelID)
        {
            return _context.Students.Where(h => h.Hostel_Id == HostelID);
        }

        public Student SearchStudent(string searchString, bool searchByName = false)
        {
            // Search by name
            if (searchByName)
            {
                return _context.Students.FirstOrDefault(s => s.FName.Contains(searchString) || s.LName.Contains(searchString));
            }
            // Search by phone
            else
            {
                return _context.StudentPhones
                                            .Where(sp => sp.Phone_no == searchString)
                                            .Include(s => s.Student)
                                            .Select(c => c.Student)
                                            .SingleOrDefault();
            }
        }

        public IEnumerable<Student> GetStudentsWithAgeAbove(TimeSpan age)
        {
            return _context.Students.Where(s => DateTime.Now.Subtract(s.DOB) > age);
        }

        public IEnumerable<Student> PaginateStudents(int page, int pageSize)
        {
            return _context.Students.Skip((page-1)*pageSize).Take(pageSize).ToList();
        }
    }
}
