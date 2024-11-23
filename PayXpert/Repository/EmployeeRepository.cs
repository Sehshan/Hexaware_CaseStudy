using PayXpert.Exceptions;
using PayXpert.Model;
using PayXpert.Repository;
using PayXpert.Utility;
using System.Data.SqlClient;
namespace PayXpert.Repository
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        private string _connectionString;

        public EmployeeRepository()
        {
            _connectionString = DBConnUtil.GetConnectionString();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            Employee employee = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "SELECT * FROM Employee WHERE EmployeeID = @EmployeeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeId);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                employee = new Employee
                                {
                                    EmployeeId = employeeId,
                                    FirstName = (string)reader["FirstName"],
                                    LastName = (string)reader["LastName"],
                                    DateOfBirth = (DateTime)reader["DateOfBirth"],
                                    Gender = (string)reader["Gender"],
                                    Email = (string)reader["Email"],
                                    PhoneNumber = (string)reader["PhoneNumber"],
                                    Address = (string)reader["Address"],
                                    Position = (string)reader["Position"],
                                    JoiningDate = (DateTime)reader["JoiningDate"],
                                    TerminationDate = reader["TerminationDate"] as DateTime?
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching employee by ID: " + ex.Message);
                }
            }
            return employee;
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "SELECT * FROM Employee";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                employees.Add(new Employee
                                {
                                    EmployeeId = (int)reader["EmployeeId"],
                                    FirstName = (string)reader["FirstName"],
                                    LastName = (string)reader["LastName"],
                                    DateOfBirth = (DateTime)reader["DateOfBirth"],
                                    Gender = (string)reader["Gender"],
                                    Email = (string)reader["Email"],
                                    PhoneNumber = (string)reader["PhoneNumber"],
                                    Address = (string)reader["Address"],
                                    Position = (string)reader["Position"],
                                    JoiningDate = (DateTime)reader["JoiningDate"],
                                    TerminationDate = reader["TerminationDate"] as DateTime?
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching employees: " + ex.Message);
                }
            }

            return employees;
        }

        public void AddEmployee(Employee employeeData)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "INSERT INTO Employee (FirstName, LastName, DateOfBirth, Gender, Email, PhoneNumber, Address, Position, JoiningDate, TerminationDate) " +
                                   "VALUES (@FirstName, @LastName, @DateOfBirth, @Gender, @Email, @PhoneNumber, @Address, @Position, @JoiningDate, @TerminationDate)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", employeeData.FirstName);
                        command.Parameters.AddWithValue("@LastName", employeeData.LastName);
                        command.Parameters.AddWithValue("@DateOfBirth", employeeData.DateOfBirth);
                        command.Parameters.AddWithValue("@Gender", employeeData.Gender);
                        command.Parameters.AddWithValue("@Email", employeeData.Email);
                        command.Parameters.AddWithValue("@PhoneNumber", employeeData.PhoneNumber);
                        command.Parameters.AddWithValue("@Address", employeeData.Address);
                        command.Parameters.AddWithValue("@Position", employeeData.Position);
                        command.Parameters.AddWithValue("@JoiningDate", employeeData.JoiningDate);
                        if (employeeData.TerminationDate.HasValue)
                        {
                            command.Parameters.AddWithValue("@TerminationDate", employeeData.TerminationDate.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@TerminationDate", DBNull.Value);
                        }
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Employee added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add the employee.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding employee: " + ex.Message);
                }
            }
        }

        public void UpdateEmployee(Employee employeeData)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "UPDATE Employee SET " +
                                   "FirstName = @FirstName, " +
                                   "LastName = @LastName, " +
                                   "DateOfBirth = @DateOfBirth, " +
                                   "Gender = @Gender, " +
                                   "Email = @Email, " +
                                   "PhoneNumber = @PhoneNumber, " +
                                   "Address = @Address, " +
                                   "Position = @Position, " +
                                   "JoiningDate = @JoiningDate, " +
                                   "TerminationDate = @TerminationDate " +
                                   "WHERE EmployeeID = @EmployeeID";  

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", employeeData.FirstName);
                        command.Parameters.AddWithValue("@LastName", employeeData.LastName);
                        command.Parameters.AddWithValue("@DateOfBirth", employeeData.DateOfBirth);
                        command.Parameters.AddWithValue("@Gender", employeeData.Gender);
                        command.Parameters.AddWithValue("@Email", employeeData.Email);
                        command.Parameters.AddWithValue("@PhoneNumber", employeeData.PhoneNumber);
                        command.Parameters.AddWithValue("@Address", employeeData.Address);
                        command.Parameters.AddWithValue("@Position", employeeData.Position);
                        command.Parameters.AddWithValue("@JoiningDate", employeeData.JoiningDate);

                        if (employeeData.TerminationDate.HasValue)
                        {
                            command.Parameters.AddWithValue("@TerminationDate", employeeData.TerminationDate.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@TerminationDate", DBNull.Value);
                        }

                        command.Parameters.AddWithValue("@EmployeeID", employeeData.EmployeeId); 

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Employee updated successfully.");
                        }
                        else
                        {
                            throw new EmployeeNotFoundException($"Employee with ID {employeeData.EmployeeId} not found.");
                        }
                    }
                }
                catch (EmployeeNotFoundException ex)
                {
                    Console.WriteLine("Error updating employee: " + ex.Message);
                }
            }
        }

        public void RemoveEmployee(int employeeId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeId);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Employee removed successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to remove the employee. Employee ID may not exist.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error removing employee in repository: " + ex.Message);
                }
            }
        }
    }
}