using PayXpert.Model;
using PayXpert.Exceptions;
using PayXpert.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Repository
{
    internal class TaxRepository : ITaxRepository
    {
        private string _connectionString;

        public TaxRepository()
        {
            _connectionString = DBConnUtil.GetConnectionString();
        }

        public decimal CalculateTax(int employeeId, int taxYear)
        {
            decimal taxAmount = 0m;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "SELECT TaxableIncome FROM Tax WHERE EmployeeID = @EmployeeID AND TaxYear = @TaxYear";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeId);
                        command.Parameters.AddWithValue("@TaxYear", taxYear);

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            decimal taxableIncome = Convert.ToDecimal(result);
                            taxAmount = CalculateTaxAmount(taxableIncome);
                        }
                        else
                        {
                            throw new TaxCalculationException($"Invalid taxable income for employee {employeeId} in year {taxYear}.");
                        }
                    }
                }
                catch (TaxCalculationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return taxAmount;
        }

        private decimal CalculateTaxAmount(decimal taxableIncome)
        {
            decimal taxAmount = 0m;

            if (taxableIncome <= 250000)
            {
                taxAmount = 0;
            }
            else if (taxableIncome <= 500000)
            {
                taxAmount = taxableIncome * 0.05m; // 5% tax
            }
            else if (taxableIncome <= 1000000)
            {
                taxAmount = taxableIncome * 0.1m; // 10% tax
            }
            else
            {
                taxAmount = taxableIncome * 0.2m; // 20% tax
            }

            return taxAmount;
        }

        public Tax GetTaxById(int taxId)
        {
            Tax tax = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "SELECT * FROM Tax WHERE TaxID = @TaxID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TaxID", taxId);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                tax = new Tax
                                {
                                    TaxID = Convert.ToInt32(reader["TaxID"]),
                                    EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                                    TaxYear = Convert.ToInt32(reader["TaxYear"]),
                                    TaxableIncome = Convert.ToDecimal(reader["TaxableIncome"]),
                                    TaxAmount = Convert.ToDecimal(reader["TaxAmount"])
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving tax details: " + ex.Message);
                }
            }

            return tax;
        }

        public List<Tax> GetTaxesForEmployee(int employeeId)
        {
            List<Tax> taxes = new List<Tax>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "SELECT * FROM Tax WHERE EmployeeID = @EmployeeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeId);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Tax tax = new Tax
                                {
                                    TaxID = Convert.ToInt32(reader["TaxID"]),
                                    EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                                    TaxYear = Convert.ToInt32(reader["TaxYear"]),
                                    TaxableIncome = Convert.ToDecimal(reader["TaxableIncome"]),
                                    TaxAmount = Convert.ToDecimal(reader["TaxAmount"])
                                };

                                taxes.Add(tax);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving taxes for employee: " + ex.Message);
                }
            }

            return taxes;
        }

        public List<Tax> GetTaxesForYear(int taxYear)
        {
            List<Tax> taxes = new List<Tax>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "SELECT * FROM Tax WHERE TaxYear = @TaxYear";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TaxYear", taxYear);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Tax tax = new Tax
                                {
                                    TaxID = Convert.ToInt32(reader["TaxID"]),
                                    EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                                    TaxYear = Convert.ToInt32(reader["TaxYear"]),
                                    TaxableIncome = Convert.ToDecimal(reader["TaxableIncome"]),
                                    TaxAmount = Convert.ToDecimal(reader["TaxAmount"])
                                };

                                taxes.Add(tax);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving taxes for year: " + ex.Message);
                }
            }

            return taxes;
        }
    }
}
