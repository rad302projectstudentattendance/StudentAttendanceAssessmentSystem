using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAALibrary
{
    public class StudentGrade : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Grade")]
        public float Grade { get; set; }

        [ForeignKey("Assessment")]
        public int AssessmentID { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }


        public virtual Student Student { get; set; }
        public virtual Assessment Assessment { get; set; }

    }
}
