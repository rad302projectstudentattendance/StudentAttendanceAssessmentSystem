using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAAWebApi.Models.DTO
{
    public class StudentGradeDTO
    {
        public int ID { get; set; }

        public float Grade { get; set; }

        public AssessmentDTO AssessmentName { get; set; }

        public StudentDTO StudentName { get; set; }

    }
}