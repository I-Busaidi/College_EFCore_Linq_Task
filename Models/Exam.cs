using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace College_EFCore_Linq_Task.Models
{
    [PrimaryKey(nameof(Dept_Id), nameof(Exam_Code))]
    public class Exam
    {
        [ForeignKey("Department")]
        public int Dept_Id { get; set; }
        public virtual Department Department { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Exam_Code { get; set; }

        [Required]
        public int Room { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        [Required]
        public TimeOnly Time { get; set; }
    }
}
