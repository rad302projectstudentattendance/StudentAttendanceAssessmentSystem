using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentAAWebApi.Models.DTO;

namespace StudentAAWebApi.DAL
{
    interface IAssessmentRepository: IDisposable
    {
        IEnumerable<AssessmentDTO> GetAssessments();
        AssessmentDTO GetAssessmentByID(int assessmentID);
    }
}
