using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentAALibrary;

namespace StudentAAWebApi.DAL
{
    interface IModuleRepository: IDisposable
    {
        IEnumerable<Module> GetModules();
        Module GetModuleByID(int moduleID);
    }
}
