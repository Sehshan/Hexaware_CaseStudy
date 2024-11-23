using PayXpert.Model;

namespace PayXpert.Service
{
    internal interface IFinancialRecordService
    {
        public interface IFinancialRecordService
        {
            void AddFinancialRecord(int employeeId, string description, decimal amount, string recordType);
            public void GetFinancialRecordById(int recordId);

            public void GetFinancialRecordsForEmployee(int employeeId);

            public void GetFinancialRecordsForDate(DateTime recordDate);
        }

    }
}
