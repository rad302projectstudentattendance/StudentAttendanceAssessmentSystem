using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAAWebApi.Models.DTO
{
    public class StudentDTO
    {
        public int ID { get; set; }

        public string StudentID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}