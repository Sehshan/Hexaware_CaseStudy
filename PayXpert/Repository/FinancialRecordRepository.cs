using PayXpert.Exceptions;
using PayXpert.Model;
using PayXpert.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Repository
{
    internal class FinancialRecordRepository : IFinancialRecordRepository
    {
        private string _connectionString;

        public FinancialRecordRepository()
        {
            _connectionString = DBConnUtil.GetConnectionString();
        }

        public void AddFinancialRecord(int employeeId, string description, decimal amount, string recordType)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = @"INSERT INTO FinancialRecord (EmployeeID, Description, Amount, RecordType, RecordDate)
                                     VALUES (@EmployeeID, @Description, @Amount, @RecordType, @RecordDate)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeId);
                        command.Parameters.AddWithValue("@Description", description);
                        command.Parameters.AddWithValue("@Amount", amount);
                        command.Parameters.AddWithValue("@RecordType", recordType);
                        command.Parameters.AddWithValue("@RecordDate", DateTime.Now);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Financial record added successfully.");
                        }
                        else
                        {
                            throw new FinancialRecordException($"Financial record not added for Employee ID: {employeeId}");
                        }
                    }
                }
                catch (FinancialRecordException ex)
                {
                    Console.WriteLine("Error while adding financial record: " + ex.Message);
                }
            }
        }

        public FinancialRecord GetFinancialRecordById(int recordId)
        {
            FinancialRecord record = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "SELECT * FROM FinancialRecord WHERE RecordID = @RecordID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RecordID", recordId);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                record = new FinancialRecord
                                {
                                    RecordID = Convert.ToInt32(reader["RecordID"]),
                                    EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                                    Description = reader["Description"].ToString(),
                                    Amount = Convert.ToDecimal(reader["Amount"]),
                                    RecordType = reader["RecordType"].ToString(),
                                    RecordDate = Convert.ToDateTime(reader["RecordDate"])
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving financial record: " + ex.Message);
                }
            }
            return record;
        }

        public List<FinancialRecord> GetFinancialRecordsForEmployee(int employeeId)
        {
            List<FinancialRecord> records = new List<FinancialRecord>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "SELECT * FROM FinancialRecord WHERE EmployeeID = @EmployeeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeId);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FinancialRecord record = new FinancialRecord
                                {
                                    RecordID = Convert.ToInt32(reader["RecordID"]),
                                    EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                                    Description = reader["Description"].ToString(),
                                    Amount = Convert.ToDecimal(reader["Amount"]),
                                    RecordType = reader["RecordType"].ToString(),
                                    RecordDate = Convert.ToDateTime(reader["RecordDate"])
                                };
                                records.Add(record);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving financial records for employee: " + ex.Message);
                }
            }
            return records;
        }

        public List<FinancialRecord> GetFinancialRecordsForDate(DateTime recordDate)
        {
            List<FinancialRecord> records = new List<FinancialRecord>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "SELECT * FROM FinancialRecord WHERE CAST(RecordDate AS DATE) = @RecordDate";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RecordDate", recordDate.Date);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FinancialRecord record = new FinancialRecord
                                {
                                    RecordID = Convert.ToInt32(reader["RecordID"]),
                                    EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                                    Description = reader["Description"].ToString(),
                                    Amount = Convert.ToDecimal(reader["Amount"]),
                                    RecordType = reader["RecordType"].ToString(),
                                    RecordDate = Convert.ToDateTime(reader["RecordDate"])
                                };
                                records.Add(record);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving financial records for date: " + ex.Message);
                }
            }
            return records;
        }
    }
}