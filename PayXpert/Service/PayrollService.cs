using PayXpert.Exceptions;
using PayXpert.Model;
using PayXpert.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Service
{
    internal class PayrollService : IPayrollService
    {
        private PayrollRepository _payrollRepository;

        public PayrollService()
        {
            _payrollRepository = new PayrollRepository();
        }

        public List<Payroll> GeneratePayroll(int employeeId, DateTime startDate, DateTime endDate)
        {
            try
            {
                if (startDate >= endDate)
                {
                    throw new InvalidInputException("Start date must be earlier than the end date.");
                }

                List<Payroll> payrolls = _payrollRepository.GeneratePayroll(employeeId, startDate, endDate);

                if (payrolls == null || payrolls.Count == 0)
                {
                    throw new PayrollGenerationException($"No payroll records found for Employee ID {employeeId} in the specified date range.");
                }
                else
                {
                    Console.WriteLine("Payroll successfully generated");
                }

                return payrolls;
            }
            catch (EmployeeNotFoundException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (PayrollGenerationException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error: " + ex.Message);
            }

            return null;
        }

        public void GetPayrollById(int payrollId)
        {
           Payroll payroll = _payrollRepository.GetPayrollById(payrollId);
            try
            {
                if (payroll == null)
                {
                    throw new PayrollGenerationException($"Payroll not found for Payroll ID {payrollId}:");
                }

                Console.WriteLine($"Payroll ID: {payroll.PayrollID}, Employee ID: {payroll.EmployeeID}, " +
                                    $"Pay Period: {payroll.PayPeriodStartDate.ToShortDateString()} - {payroll.PayPeriodEndDate.ToShortDateString()}, " +
                                    $"Basic Salary: {payroll.BasicSalary}, Overtime Pay: {payroll.OvertimePay}, Deductions: {payroll.Deductions}, " +
                                    $"Net Salary: {payroll.NetSalary}");
            }
            catch (PayrollGenerationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetPayrollsForEmployee(int employeeId)
        {
            List<Payroll> payrolls = _payrollRepository.GetPayrollsForEmployee(employeeId);

            if (payrolls.Count == 0)
            {
                Console.WriteLine("No payroll records found for Employee ID: " + employeeId);
            }
            else
            {
                foreach (var payroll in payrolls)
                {
                    Console.WriteLine($"Payroll ID: {payroll.PayrollID}, Employee ID: {payroll.EmployeeID}, " +
                                       $"Pay Period: {payroll.PayPeriodStartDate.ToShortDateString()} - {payroll.PayPeriodEndDate.ToShortDateString()}, " +
                                       $"Basic Salary: {payroll.BasicSalary}, Overtime Pay: {payroll.OvertimePay}, " +
                                       $"Deductions: {payroll.Deductions}, Net Salary: {payroll.NetSalary}");
                }
            }
        }


        public void GetPayrollsForPeriod(DateTime startDate, DateTime endDate)
        {
            List<Payroll> payrolls = _payrollRepository.GetPayrollsForPeriod(startDate, endDate);

            if (payrolls.Count == 0)
            {
                Console.WriteLine("No payroll records found for the given period.");
            }
            else
            {
                foreach (var payroll in payrolls)
                {
                    Console.WriteLine($"Payroll ID: {payroll.PayrollID}, Employee ID: {payroll.EmployeeID}, " +
                                       $"Pay Period: {payroll.PayPeriodStartDate.ToShortDateString()} - {payroll.PayPeriodEndDate.ToShortDateString()}, " +
                                       $"Basic Salary: {payroll.BasicSalary}, Overtime Pay: {payroll.OvertimePay}, " +
                                       $"Deductions: {payroll.Deductions}, Net Salary: {payroll.NetSalary}");
                }
            }
        }
    }
}