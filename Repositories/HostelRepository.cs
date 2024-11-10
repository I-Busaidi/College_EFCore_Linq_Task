using College_EFCore_Linq_Task.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_EFCore_Linq_Task.Repositories
{
    public class HostelRepository
    {
        private readonly ApplicationDbContext _context;
        public HostelRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Hostel> GetAllHostels()
        {
            return _context.Hostels.Include(s => s.Students);
        }

        public Hostel GetHostelById(int HostelId)
        {
            return _context.Hostels.Where(h => h.Hostel_Id == HostelId)
                                   .Include(s => s.Students)
                                   .SingleOrDefault();
        }

        public void AddHostel(Hostel hostel)
        {
            _context.Hostels.Add(hostel);
            _context.SaveChanges();
        }

        public void UpdateHostel(Hostel hostel)
        {
            _context.Hostels.Update(hostel);
            _context.SaveChanges();
        }

        public void DeleteHostel(int hostelID)
        {
            var hostel = GetHostelById(hostelID);
            if (hostel != null)
            {
                _context.Hostels.Remove(hostel);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Hostel> GetHostelByCity(string city)
        {
            return _context.Students.Where(s => s.City == city)
                                    .Include(h => h.Hostel)
                                    .Select(h => h.Hostel);
        }

        public int CountHostelsWithAvailableSeats()
        {
            return _context.Hostels.Where(h => h.No_of_seats > 0).Count();
        }
    }
}
