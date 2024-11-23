using PayXpert.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Repository
{
    internal interface IFinancialRecordRepository
    {
        void AddFinancialRecord(int employeeId, string description, decimal amount, string recordType);

        public FinancialRecord GetFinancialRecordById(int recordId);

        public List<FinancialRecord> GetFinancialRecordsForEmployee(int employeeId);

        public List<FinancialRecord> GetFinancialRecordsForDate(DateTime recordDate);
    }
}
