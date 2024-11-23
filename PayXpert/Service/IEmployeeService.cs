using PayXpert.Model;

namespace PayXpert.Service
{
    internal interface IEmployeeService
    {
        public void GetEmployeeById(int employeeId);   //that the method will return an instance of that class.
        public void GetAllEmployees();
        public void AddEmployee(Employee employeeData);
        public  void UpdateEmployee(Employee employeeData);
        public void RemoveEmployee(int employeeId);
    }
}