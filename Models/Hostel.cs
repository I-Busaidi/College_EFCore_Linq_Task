using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_EFCore_Linq_Task.Models
{
    public class Hostel
    {
        [Key]
        public int Hostel_Id { get; set; }

        [Required]
        public string Hostel_Name { get; set; }

        public int No_of_seats { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
