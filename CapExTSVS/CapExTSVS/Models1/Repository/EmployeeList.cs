using CapExTSVS.Models1;

using System.Collections.Generic;

namespace MVC_CRUD_LIST.Repository
{
    public static class EmployeeList
    {
        static List<CapexmainRequestItems> empList = null;
        static EmployeeList()
        {
            empList = new List<CapexmainRequestItems>();       
           
        }

        public static List<CapexmainRequestItems> SelectEmployeeList()
        {       
            return empList;
        }

        public static void InsertEmployeeList(CapexmainRequestItems emp)
        {
            empList.Add(emp);
        }

        public static void UpdateEmployeeList(CapexmainRequestItems emp)
        {
            //Employee empUpdate = empList.Find(x => x.EmployeeID == emp.EmployeeID);
            //empUpdate.Name = emp.Name;
            //empUpdate.Age = emp.Age;
            //empUpdate.State = emp.State;
            //empUpdate.Country = emp.Country;
        }
        public static void DeleteEmployeeList(int id)
        {
            CapexmainRequestItems empDelete = empList.Find(x => x.ID == id.ToString());
            empList.Remove(empDelete);
        }
    }
}