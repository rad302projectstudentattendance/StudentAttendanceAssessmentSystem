using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAALibrary
{
    public class Module
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Module")]
        public string ModuleName { get; set; }

        public virtual ICollection<Lecturer> Lecturers { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Assessment> Assessments { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
