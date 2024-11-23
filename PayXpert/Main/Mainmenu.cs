using PayXpert.Model;
using PayXpert.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Main
{
    internal class Mainmenu
    {
        public static void payXpert()
        {
            EmployeeService employeeService = new EmployeeService();
            PayrollService payrollService = new PayrollService();
            TaxService taxService = new TaxService();
            FinancialRecordService financialRecord = new FinancialRecordService();

            while (true)
            {
                Console.WriteLine("PayXpert Employee Management System");
                Console.WriteLine("1. Get Employee by ID ");
                Console.WriteLine("2. Get All Employees ");
                Console.WriteLine("3. Add Employee");
                Console.WriteLine("4. Update Employee");
                Console.WriteLine("5. Remove Employee");
                Console.WriteLine("6. Generate Payroll");
                Console.WriteLine("7. Get Payroll by PayrollId");
                Console.WriteLine("8. Get Payroll by EmployeeId");
                Console.WriteLine("9. Get Payroll for Period");
                Console.WriteLine("10. Calculate Tax");
                Console.WriteLine("11. Get Tax by TaxId");
                Console.WriteLine("12. Get Tax by EmployeeId");
                Console.WriteLine("13. Get Tax for Year");
                Console.WriteLine("14. Add Financial Record");
                Console.WriteLine("15. Get Financial Record by Id");
                Console.WriteLine("16. Get Financial Record for Employee");
                Console.WriteLine("17. Get Financial Record for Date");

                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter employee Id:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        employeeService.GetEmployeeById(id);

                        break;

                    case "2":
                        Console.Write("All Employees ");
                        employeeService.GetAllEmployees();

                        break;

                    case "3":
                        Employee newEmployee = new Employee();
                        employeeService.AddEmployee(newEmployee);

                        break;

                    case "4":
                        Employee employee = new Employee();
                        employeeService.UpdateEmployee(employee);
                        
                        break;

                    case "5":

                        Console.WriteLine("Enter the Employee ID to remove:");
                        int employeeId = int.Parse(Console.ReadLine());
                        employeeService.RemoveEmployee(employeeId);

                        break;

                    case "6":
                        Console.WriteLine("Enter Employee id");
                        int employeeidforPay = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter start date (yyyy-MM-dd):");
                        DateTime startpay = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("Enter end date (yyyy-MM-dd):");
                        DateTime endpay = DateTime.Parse(Console.ReadLine());

                        payrollService.GeneratePayroll(employeeidforPay,startpay, endpay);
                        break;

                    case "7":
                        Console.WriteLine("Enter your Payroll Id");
                        int payrollId = int.Parse(Console.ReadLine());
                        payrollService.GetPayrollById(payrollId);
                        break;

                    case "8":
                        Console.WriteLine("Enter your EmployeeId");
                        int employeeIdforPayroll = Convert.ToInt32(Console.ReadLine());
                        payrollService.GetPayrollsForEmployee(employeeIdforPayroll);
                        break;

                    case "9":
                        Console.WriteLine("Enter Start date");
                        DateTime start = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Enter End date");
                        DateTime end = Convert.ToDateTime(Console.ReadLine());
                        payrollService.GetPayrollsForPeriod(start, end);
                        break;

                    case "10":
                        Console.WriteLine("Enter EmployeeID");
                        int employeeIdfortax = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the tax year");
                        int year = Convert.ToInt32(Console.ReadLine());
                        taxService.CalculateTax(employeeIdfortax, year);

                        break;


                    case "11":
                        Console.WriteLine("Enter TaxId");
                        int taxId = Convert.ToInt32(Console.ReadLine());
                        taxService.GetTaxById(taxId);

                        break;

                    case "12":
                        Console.WriteLine("Enter EmployeeId");
                        int employeeIdtoGetTax = Convert.ToInt32(Console.ReadLine());
                        taxService.GetTaxesForEmployee(employeeIdtoGetTax);
                        break;

                    case "13":
                        Console.WriteLine("Enter the Year");
                        int yearForTax = Convert.ToInt32(Console.ReadLine());
                        taxService.GetTaxesForYear(yearForTax);
                        break;

                    case "14":
                        Console.WriteLine("Enter EmployeeId");
                        int employeeIdForFR = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Description");
                        string description = Console.ReadLine();
                        Console.WriteLine("Enter Amount");
                        decimal amount = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Enter Record-Type ['Income, Expense, Tax Payment, Others]");
                        string type = Console.ReadLine();
                        financialRecord.AddFinancialRecord(employeeIdForFR,description,amount,type);

                        break;

                    case "15":
                        Console.WriteLine("Enter RecordId");
                        int recordId = Convert.ToInt32(Console.ReadLine());
                        financialRecord.GetFinancialRecordById(recordId);

                        break;

                    case "16":
                        Console.WriteLine("Enter EmployeeId");
                        int employeeIdforFinRec = Convert.ToInt32(Console.ReadLine());
                        financialRecord.GetFinancialRecordsForEmployee(employeeIdforFinRec);

                        break;

                    case "17":
                        Console.WriteLine("Enter the date");
                        DateTime date = Convert.ToDateTime(Console.ReadLine());
                        financialRecord.GetFinancialRecordsForDate(date);

                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}