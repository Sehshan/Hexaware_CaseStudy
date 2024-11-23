using PayXpert.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Repository
{
    internal interface IEmployeeRepository
    {
        public Employee GetEmployeeById(int employeeId);   //that the method will return an instance of that class.
        List<Employee> GetAllEmployees();
        void AddEmployee(Employee employeeData);
        void UpdateEmployee(Employee employeeData);
        void RemoveEmployee(int employeeId);
        
    }
}
