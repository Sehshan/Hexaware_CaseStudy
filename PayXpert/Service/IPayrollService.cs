using PayXpert.Model;

namespace PayXpert.Service
{
    internal interface IPayrollService
    {
        public interface IPayrollService
        {
            public List<Payroll> GeneratePayroll(int employeeId, DateTime startDate, DateTime endDate);
            void GetPayrollById(int payrollId);
            void GetPayrollsForEmployee(int employeeId);
            void GetPayrollsForPeriod(DateTime startDate, DateTime endDate);
        }
    }
}