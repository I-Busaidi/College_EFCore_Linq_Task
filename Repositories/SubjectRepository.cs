using College_EFCore_Linq_Task.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_EFCore_Linq_Task.Repositories
{
    public class SubjectRepository
    {
        private readonly ApplicationDbContext _context;
        public SubjectRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return _context.Subjects.Include(s => s.Teacher);
        }

        public Subject GetSubjectById(int subjectId)
        {
            return _context.Subjects.Where(s => s.Subject_Id == subjectId)
                                    .Include(s => s.Teacher)
                                    .SingleOrDefault();
        }

        public void AddSubject(Subject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
        }

        public void UpdateSubject(Subject subject)
        {
            _context.Subjects.Update(subject);
            _context.SaveChanges();
        }

        public void DeleteSubject(int Subject_Id)
        {
            var subject = GetSubjectById(Subject_Id);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Subject> GetSubjectsTaughtByFaculty(int FID)
        {
            return _context.Subjects.Where(s => s.Teacher_Id == FID).ToList();
        }

        public int CountSubjects()
        {
            return _context.Subjects.Count();
        }
    }
}
