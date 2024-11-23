using PayXpert.Model;
using PayXpert.Utility;
using PayXpert.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Repository
{
    internal class PayrollRepository : IPayrollRepository
    {
        private string _connectionString;

        public PayrollRepository()
        {
            _connectionString = DBConnUtil.GetConnectionString();
        }

        public List<Payroll> GeneratePayroll(int employeeId, DateTime startDate, DateTime endDate)
        {
            List<Payroll> payrolls = new List<Payroll>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = @"SELECT * FROM Payroll 
                             WHERE EmployeeID = @EmployeeID 
                             AND PayPeriodStartDate >= @StartDate 
                             AND PayPeriodEndDate <= @EndDate";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeId);
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Payroll payroll = new Payroll
                                {
                                    PayrollID = Convert.ToInt32(reader["PayrollID"]),
                                    EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                                    PayPeriodStartDate = Convert.ToDateTime(reader["PayPeriodStartDate"]),
                                    PayPeriodEndDate = Convert.ToDateTime(reader["PayPeriodEndDate"]),
                                    BasicSalary = Convert.ToDecimal(reader["BasicSalary"]),
                                    OvertimePay = Convert.ToDecimal(reader["OvertimePay"]),
                                    Deductions = Convert.ToDecimal(reader["Deductions"]),
                                    NetSalary = Convert.ToDecimal(reader["NetSalary"])
                                };

                                payrolls.Add(payroll);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new DatabaseConnectionException("Error retrieving payrolls: " + ex.Message);
                }
            }

            return payrolls;
        }

        public Payroll GetPayrollById(int payrollId)
        {
            Payroll payroll = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "SELECT * FROM Payroll WHERE PayrollID = @PayrollID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PayrollID", payrollId);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                payroll = new Payroll
                                {
                                    PayrollID = Convert.ToInt32(reader["PayrollID"]),
                                    EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                                    PayPeriodStartDate = Convert.ToDateTime(reader["PayPeriodStartDate"]),
                                    PayPeriodEndDate = Convert.ToDateTime(reader["PayPeriodEndDate"]),
                                    BasicSalary = Convert.ToDecimal(reader["BasicSalary"]),
                                    OvertimePay = Convert.ToDecimal(reader["OvertimePay"]),
                                    Deductions = Convert.ToDecimal(reader["Deductions"]),
                                    NetSalary = Convert.ToDecimal(reader["NetSalary"])
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving payroll by ID: " + ex.Message);
                }
            }
            return payroll;
        }

        public List<Payroll> GetPayrollsForEmployee(int employeeId)
        {
            List<Payroll> payrolls = new List<Payroll>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "SELECT * FROM Payroll WHERE EmployeeID = @EmployeeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeId);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Payroll payroll = new Payroll
                                {
                                    PayrollID = Convert.ToInt32(reader["PayrollID"]),
                                    EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                                    PayPeriodStartDate = Convert.ToDateTime(reader["PayPeriodStartDate"]),
                                    PayPeriodEndDate = Convert.ToDateTime(reader["PayPeriodEndDate"]),
                                    BasicSalary = Convert.ToDecimal(reader["BasicSalary"]),
                                    OvertimePay = Convert.ToDecimal(reader["OvertimePay"]),
                                    Deductions = Convert.ToDecimal(reader["Deductions"]),
                                    NetSalary = Convert.ToDecimal(reader["NetSalary"])
                                };
                                payrolls.Add(payroll);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving payrolls for employee: " + ex.Message);
                }
            }
            return payrolls;
        }

        public List<Payroll> GetPayrollsForPeriod(DateTime startDate, DateTime endDate)
        {
            List<Payroll> payrolls = new List<Payroll>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "SELECT * FROM Payroll WHERE PayPeriodStartDate >= @StartDate AND PayPeriodEndDate <= @EndDate";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Payroll payroll = new Payroll
                                {
                                    PayrollID = Convert.ToInt32(reader["PayrollID"]),
                                    EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                                    PayPeriodStartDate = Convert.ToDateTime(reader["PayPeriodStartDate"]),
                                    PayPeriodEndDate = Convert.ToDateTime(reader["PayPeriodEndDate"]),
                                    BasicSalary = Convert.ToDecimal(reader["BasicSalary"]),
                                    OvertimePay = Convert.ToDecimal(reader["OvertimePay"]),
                                    Deductions = Convert.ToDecimal(reader["Deductions"]),
                                    NetSalary = Convert.ToDecimal(reader["NetSalary"])
                                };
                                payrolls.Add(payroll);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving payrolls for the period: " + ex.Message);
                }
            }
            return payrolls;
        }
    }
}