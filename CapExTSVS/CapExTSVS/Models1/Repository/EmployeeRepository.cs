using CapExTSVS.Models1;
using System.Collections.Generic;

namespace MVC_CRUD_LIST.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {        
        public List<CapexmainRequestItems> SelectAllEmployees()
        {
            return EmployeeList.SelectEmployeeList();
        }

        public CapexmainRequestItems SelectEmployeeById(int id)
        {
            return EmployeeList.SelectEmployeeList().Find(x=>x.ID == id.ToString());
        }

        public void InsertEmployee(CapexmainRequestItems emp)
        {
            EmployeeList.InsertEmployeeList(emp);
        }

        public void UpdateEmployee(CapexmainRequestItems emp)
        {
            EmployeeList.UpdateEmployeeList(emp);
        }

        public void DeleteEmployee(int id)
        {
            EmployeeList.DeleteEmployeeList(id);
        }
    }
}