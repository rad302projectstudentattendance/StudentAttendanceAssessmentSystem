using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAALibrary
{
    public class StudentAAContext : DbContext
    {
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<StudentGrade> StudentGrades { get; set; }
        public StudentAAContext(): base("SAATest")
        {

        }
    }
}
