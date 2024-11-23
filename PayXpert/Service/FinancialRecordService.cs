using PayXpert.Model;
using PayXpert.Exceptions;
using PayXpert.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Service
{
    internal class FinancialRecordService : IFinancialRecordService
    {
        private FinancialRecordRepository _financialRecordRepository;

        public FinancialRecordService()
        {
            _financialRecordRepository = new FinancialRecordRepository();
        }

        public void AddFinancialRecord(int employeeId, string description, decimal amount, string recordType)
        {
            try
            {
                if (employeeId <= 0 || string.IsNullOrWhiteSpace(description) || amount <= 0 || string.IsNullOrWhiteSpace(recordType))
                {
                    throw new FinancialRecordException("Invalid input. Please check the provided data.");
                }

                _financialRecordRepository.AddFinancialRecord(employeeId, description, amount, recordType);
            }
            catch (FinancialRecordException ex)
            {
                Console.WriteLine("Error while adding financial record: " + ex.Message);
            }
        }

        public void GetFinancialRecordById(int recordId)
        {
            FinancialRecord record = _financialRecordRepository.GetFinancialRecordById(recordId);
            try
            {
                if (record == null)
                {
                    throw new FinancialRecordException($"Financial record not found for Record ID: {recordId}");
                }
                else
                {
                    Console.WriteLine($"Record ID: {record.RecordID}, Employee ID: {record.EmployeeID}, " +
                        $"Description: {record.Description}, Amount: {record.Amount}, " +
                        $"Record Type: {record.RecordType}, Created On: {record.RecordDate}");
                }
            }
            catch(FinancialRecordException ex)
            {
                Console.WriteLine("Error in Getting Financial Record: "+ ex.Message);
            }
        }

        public void GetFinancialRecordsForEmployee(int employeeId)
        {
            List<FinancialRecord> records = _financialRecordRepository.GetFinancialRecordsForEmployee(employeeId);
            try
            {
                if (records == null || records.Count == 0)
                {
                    throw new FinancialRecordException($"No financial records found for Employee ID: {employeeId}");
                }
                else
                {
                    Console.WriteLine($"Financial Records for Employee ID: {employeeId}");
                    foreach (var record in records)
                    {
                        Console.WriteLine($"Record ID: {record.RecordID}, Description: {record.Description}, " +
                            $"Amount: {record.Amount}, Record Type: {record.RecordType}, Created On: {record.RecordDate}");
                    }
                }
            }
            catch (FinancialRecordException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void GetFinancialRecordsForDate(DateTime recordDate)
        {
            List<FinancialRecord> records = _financialRecordRepository.GetFinancialRecordsForDate(recordDate);
            try
            {
                if (records == null || records.Count == 0)
                {
                    throw new FinancialRecordException($"No financial records found for the date: {recordDate.ToShortDateString()}");
                }
                else
                {
                    Console.WriteLine($"Financial Records for Date: {recordDate.ToShortDateString()}");
                    foreach (var record in records)
                    {
                        Console.WriteLine($"Record ID: {record.RecordID}, Employee ID: {record.EmployeeID}, " +
                            $"Description: {record.Description}, Amount: {record.Amount}, " +
                            $"Record Type: {record.RecordType}, Created On: {record.RecordDate}");
                    }
                }
            }
            catch (FinancialRecordException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
