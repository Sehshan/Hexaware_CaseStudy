namespace PayXpert.Model
{
    internal class Tax
    {
        private int taxID;
        private int employeeID;
        private int taxYear;
        private decimal taxableIncome;
        private decimal taxAmount;

        // Properties
        public int TaxID
        {
            get { return taxID; }
            set { taxID = value; }
        }

        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        public int TaxYear
        {
            get { return taxYear; }
            set { taxYear = value; }
        }

        public decimal TaxableIncome
        {
            get { return taxableIncome; }
            set { taxableIncome = value; }
        }

        public decimal TaxAmount
        {
            get { return taxAmount; }
            set { taxAmount = value; }
        }

        // Default constructor
        public Tax() { }

        // Parametrized constructor
        public Tax(int taxID, int employeeID, int taxYear, decimal taxableIncome, decimal taxAmount)
        {
            TaxID = taxID;
            EmployeeID = employeeID;
            TaxYear = taxYear;
            TaxableIncome = taxableIncome;
            TaxAmount = taxAmount;
        }
    }
}