using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAAWebApi.Models.DTO
{
    public class ModuleDTO
    {
        public int ID { get; set; }
        public string ModuleName { get; set; }
        public List<LecturerDTO> Lecturers { get; set; }
        public List<StudentDTO> Students { get; set; }
    }
}