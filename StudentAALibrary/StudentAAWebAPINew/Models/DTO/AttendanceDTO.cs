using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAAWebApi.Models.DTO
{
    public class AttendanceDTO
    {
        public int ID { get; set; }
       
        public DateTime AttendanceDate { get; set; }
        
        public ModuleDTO ModuleName { get; set; }

        public List<StudentDTO> Students { get; set; }
        

    }
}