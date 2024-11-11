using College_EFCore_Linq_Task.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_EFCore_Linq_Task.Repositories
{
    public class ExamRepository
    {
        private readonly ApplicationDbContext _context;
        public ExamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Exam> GetAllExams()
        {
            return _context.Exams.Include(d => d.Department)
                                 .ThenInclude(c => c.Courses)
                                 .ThenInclude(sc => sc.StudentsInCourse)
                                 .ThenInclude(st => st.Student)
                                 .ToList();
        }

        public Exam GetExamById(int examId)
        {
            return _context.Exams.Where(e => e.Exam_Code == examId)
                                 .Include(d => d.Department)
                                 .ThenInclude(c => c.Courses)
                                 .ThenInclude(sc => sc.StudentsInCourse)
                                 .ThenInclude(st => st.Student)
                                 .SingleOrDefault();
        }

        public void AddExam(Exam exam)
        {
            _context.Exams.Add(exam);
            _context.SaveChanges();
        }

        public void UpdateExam(Exam exam)
        {
            _context.Exams.Update(exam);
            _context.SaveChanges();
        }

        public void DeleteExam(int examId)
        {
            var exam = GetExamById(examId);
            if (exam != null)
            {
                _context.Exams.Remove(exam);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Exam> GetExamsByDate(DateOnly fromDate, DateOnly toDate)
        {
            return _context.Exams.Where(e => e.Date >= fromDate && e.Date <= toDate)
                                 .ToList();
        }

        public IEnumerable<Exam> GetExamsByStudent(int studentId)
        {
            return _context.StudentCourses.Where(st => st.SID == studentId)
                                          .Include(c => c.Course)
                                          .ThenInclude(d => d.Department)
                                          .ThenInclude(e => e.Exams)
                                          .SelectMany(st => st.Course.Department.Exams)
                                          .ToList();
        }

        public int CountExamsByDepartment(int dept_Id)
        {
            return _context.Exams.Where(e => e.Dept_Id == dept_Id)
                                 .Count();
        }
    }
}
