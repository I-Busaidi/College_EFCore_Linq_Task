using College_EFCore_Linq_Task.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_EFCore_Linq_Task.Repositories
{
    public class FacultyRepository
    {
        private readonly ApplicationDbContext _context;
        public FacultyRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Faculty> GetAllFaculties()
        {
            return _context.Faculties.Include(s => s.Subjects)
                                     .Include(d => d.Department)
                                     .ThenInclude(c => c.Courses)
                                     .ToList();
        }

        public Faculty GetFacultyById(int facultyId)
        {
            return _context.Faculties.Where(f => f.FID == facultyId)
                                     .Include(sb => sb.Subjects)
                                     .Include(st => st.Students)
                                     .Include(dp => dp.Department)
                                     .ThenInclude(c => c.Courses)
                                     .SingleOrDefault();
        }

        public void AddFaculty(Faculty faculty)
        {
            _context.Faculties.Add(faculty);
            _context.SaveChanges();
        }

        public void UpdateFaculty(Faculty faculty)
        {
            _context.Faculties.Update(faculty);
            _context.SaveChanges();
        }

        public void DeleteFaculty(int FID)
        {
            var faculty = GetFacultyById(FID);
            if (faculty != null)
            {
                _context.Faculties.Remove(faculty);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Faculty> GetFacultyByDept(int Dept_Id)
        {
            return _context.Faculties.Where(f => f.DeptId == Dept_Id)
                                     .Include(sb => sb.Subjects)
                                     .Include(st => st.Students)
                                     .Include(d => d.Department)
                                     .ThenInclude(c => c.Courses)
                                     .ToList();
        }

        public Faculty GetFacultyByMobileNumber(string mobileNo)
        {
            return _context.FacultyMobiles.Where(m => m.Mobile_no == mobileNo)
                                          .Include(f => f.Faculty)
                                          .Select(m => m.Faculty)
                                          .SingleOrDefault();
        }

        public double CalculateAverageSalary()
        {
            return _context.Faculties.Average(f => f.Salary);
        }
    }
}
