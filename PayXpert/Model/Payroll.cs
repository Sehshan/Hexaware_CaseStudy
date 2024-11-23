namespace PayXpert.Model
{
    internal class Payroll
    {
        private int payrollID;
        private int employeeID;
        private DateTime payPeriodStartDate;
        private DateTime payPeriodEndDate;
        private decimal basicSalary;
        private decimal overtimePay;
        private decimal deductions;
        private decimal netSalary;

        // Properties
        public int PayrollID
        {
            get { return payrollID; }
            set { payrollID = value; }
        }

        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        public DateTime PayPeriodStartDate
        {
            get { return payPeriodStartDate; }
            set { payPeriodStartDate = value; }
        }

        public DateTime PayPeriodEndDate
        {
            get { return payPeriodEndDate; }
            set { payPeriodEndDate = value; }
        }

        public decimal BasicSalary
        {
            get { return basicSalary; }
            set { basicSalary = value; }
        }

        public decimal OvertimePay
        {
            get { return overtimePay; }
            set { overtimePay = value; }
        }

        public decimal Deductions
        {
            get { return deductions; }
            set { deductions = value; }
        }

        public decimal NetSalary
        {
            get { return netSalary; }
            set { netSalary = value; }
        }

        // Default constructor
        public Payroll() { }

        // Parametrized constructor
        public Payroll(int payrollID, int employeeID, DateTime payPeriodStartDate, DateTime payPeriodEndDate,
                       decimal basicSalary, decimal overtimePay, decimal deductions, decimal netSalary)
        {
            PayrollID = payrollID;
            EmployeeID = employeeID;
            PayPeriodStartDate = payPeriodStartDate;
            PayPeriodEndDate = payPeriodEndDate;
            BasicSalary = basicSalary;
            OvertimePay = overtimePay;
            Deductions = deductions;
            NetSalary = netSalary;
        }
    }
}