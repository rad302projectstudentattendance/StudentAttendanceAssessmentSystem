using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAALibrary
{
    public class Assessment: IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Assessment")]
        public string AssessmentName { get; set; }

        [Display(Name = "Summary")]
        public string Summary { get; set; }

        [Display(Name = "Grade(Max)")]
        public float MaxGrade { get; set; }

        [ForeignKey("Module")]
        public int ModuleID { get; set; }

        public virtual Module Module { get; set; }
       

    }
}
