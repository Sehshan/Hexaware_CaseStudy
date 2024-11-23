using PayXpert.Exceptions;
using PayXpert.Model;
using PayXpert.Repository;

namespace PayXpert.Service
{
    internal class EmployeeService : IEmployeeService
    {
        EmployeeRepository employeeRepository;

        public EmployeeService()
        {
            this.employeeRepository = new EmployeeRepository();
        }

        public void GetEmployeeById(int employeeId)
        {
            Employee employee = employeeRepository.GetEmployeeById(employeeId);
            try
            {
                if (employee == null)
                {
                    throw new EmployeeNotFoundException($"Employee with ID {employeeId} not found.");
                }
                Console.WriteLine($"Employee Found: {employee.EmployeeId} {employee.FirstName} {employee.LastName}, DateOfBirth: {employee.DateOfBirth}, Gender: {employee.Gender}, " +
                        $"Email: {employee.Email}, PhoneNumber: {employee.PhoneNumber}, Address: {employee.Address}, Position: {employee.Position}, JoiningDate: {employee.JoiningDate}, " +
                        $"TerminationDate: {employee.TerminationDate}");
            }
            catch (EmployeeNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetAllEmployees()
        {
            List<Employee> employees = employeeRepository.GetAllEmployees();

            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
            }
            else
            {
                Console.WriteLine("Employee List:");
                foreach (Employee employee in employees)
                {
                    Console.WriteLine($"ID: {employee.EmployeeId} Name: {employee.FirstName} {employee.LastName}, " +
                                      $"Date of Birth: {employee.DateOfBirth.ToShortDateString()}, Gender: {employee.Gender}, " +
                                      $"Email: {employee.Email}, Phone Number: {employee.PhoneNumber}, Address: {employee.Address}, " +
                                      $"Position: {employee.Position}, Joining Date: {employee.JoiningDate.ToShortDateString()}, " +
                                      $"Termination Date: {(employee.TerminationDate)}");
                }
            }
        }

        public void AddEmployee(Employee employeeData)
        {
            try
            {
                employeeRepository.AddEmployee(employeeData);
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine("Invalid input: " + ex.Message);
            }
            catch (DatabaseConnectionException ex)
            {
                Console.WriteLine("Database connection error: " + ex.Message);
            }
        }

        public void UpdateEmployee(Employee employeeData)
        {
            try
            {
                employeeRepository.UpdateEmployee(employeeData);
            }
            catch (EmployeeNotFoundException ex)
            {
                Console.WriteLine("Error updating employee: " + ex.Message);
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine("Invalid input: " + ex.Message);
            }
        }

        public void RemoveEmployee(int employeeId)
        {
            try
            {
                employeeRepository.RemoveEmployee(employeeId);
            }
            catch (EmployeeNotFoundException ex)
            {
                Console.WriteLine("Error removing employee: " + ex.Message);
            }
            catch (DatabaseConnectionException ex)
            {
                Console.WriteLine("Database connection error: " + ex.Message);
            }
        }
    }
}
