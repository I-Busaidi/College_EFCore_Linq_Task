using College_EFCore_Linq_Task.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_EFCore_Linq_Task.Repositories
{
    public class DepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _context.Departments.Include(d => d.Courses)
                                       .Include(d => d.Exams)
                                       .ToList();
        }

        public Department GetDepartmentById(int dept_Id)
        {
            return _context.Departments.Where(d => d.DeptId == dept_Id)
                                       .Include(d => d.Faculties)
                                       .Include(d => d.Courses)
                                       .Include(d => d.Exams)
                                       .SingleOrDefault();
        }

        public void AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
        }

        public void DeleteDepartment(int dept_Id)
        {
            var dept = GetDepartmentById(dept_Id);
            if (dept != null)
            {
                _context.Departments.Remove(dept);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Department> GetDepartmentsWithCourses()
        {
            return _context.Departments.Include(d => d.Courses)
                                       .Where(c => c.Courses.Any())
                                       .ToList();
        }

        public List<string> GetDepartmentNames()
        {
            return _context.Departments.Select(d => d.DeptName)
                                       .ToList();
        }
    }
}
