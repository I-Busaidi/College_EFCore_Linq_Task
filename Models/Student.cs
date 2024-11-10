using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_EFCore_Linq_Task.Models
{
    public class Student
    {
        [Key]
        public int SID { get; set; }

        [Required]
        public string FName { get; set; }

        [Required]
        public string LName { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Pin_code { get; set; }

        public DateTime DOB { get; set; }

        [ForeignKey("Hostel")]
        public int Hostel_Id { get; set; }
        public virtual Hostel Hostel { get; set; }

        [ForeignKey("Teacher")]
        public int FID { get; set; }
        public virtual Faculty Teacher { get; set; }

        public virtual ICollection<StudentPhone> StudentPhones { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
