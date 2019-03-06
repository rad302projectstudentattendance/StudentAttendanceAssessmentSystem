using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAALibrary
{
    public class Attendance
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime AttendanceDate { get; set; }

        [ForeignKey("Module")]
        public int ModuleID { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual Module Module { get; set; }

    }
}
