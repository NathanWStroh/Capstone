using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Farouche.Commons;
using com.Farouche.DataAccess;

namespace com.Farouche.BusinessLogic
{
    public class EmployeeManager
    {
        public static List<Employee> GetAllEmployees()
        {
            return EmployeeDAL.GetAllEmployees();
        }

        public static List<Employee> GetEmployeesByActive(bool active)
        {
            return EmployeeDAL.GetEmployeesByActive(active);
        }

        public static bool Deactivate(Commons.Employee employee)
        {
            return EmployeeDAL.SetActive(false, employee);
        }

        public static bool Activate(Commons.Employee employee)
        {
            return EmployeeDAL.SetActive(true, employee);
        }

        public static Boolean Update(Employee old, Employee edited)
        {
            return EmployeeDAL.Update(old, edited);
        }

        public static Boolean Add(Employee newEmployee, String password)
        {
            return EmployeeDAL.Add(newEmployee, password);
        }
    }
}
