using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAAWebApi.Models.DTO
{
    public class AssessmentDTO
    {
        public int ID { get; set; }

        public string AssessmentName { get; set; }

        public string Summary { get; set; }

        public float MaxGrade { get; set; }

        public ModuleDTO ModuleName { get; set; }
    }
}