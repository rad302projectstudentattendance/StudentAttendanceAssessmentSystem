using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentAALibrary;

namespace StudentAAWebApi.DAL
{
    interface IAssessmentRepository: IDisposable
    {
        IEnumerable<Assessment> GetAssessments();
        Assessment GetAssessmentByID(int assessmentID);
    }
}
