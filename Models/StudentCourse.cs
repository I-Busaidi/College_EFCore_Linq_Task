using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_EFCore_Linq_Task.Models
{
    [PrimaryKey(nameof(SID), nameof(Course_id))]
    public class StudentCourse
    {
        [ForeignKey("Student")]
        public int SID { get; set; }
        public virtual Student Student { get; set; }

        [ForeignKey("Course")]
        public int Course_id { get; set; }
        public virtual Course Course { get; set; }
    }
}
