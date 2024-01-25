using CapExTSVS.Models1;

using System.Collections.Generic;

namespace MVC_CRUD_LIST.Repository
{
    public interface IEmployeeRepository
    {
        List<CapexmainRequestItems> SelectAllEmployees();
        CapexmainRequestItems SelectEmployeeById(int id);
        void InsertEmployee(CapexmainRequestItems emp);
        void UpdateEmployee(CapexmainRequestItems emp);
        void DeleteEmployee(int id);
    }
}