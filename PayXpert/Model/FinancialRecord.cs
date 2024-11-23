namespace PayXpert.Model
{
    internal class FinancialRecord
    {
        private int recordID;
        private int employeeID;
        private DateTime recordDate;
        private string description;
        private decimal amount;
        private string recordType;

        // Properties
        public int RecordID
        {
            get { return recordID; }
            set { recordID = value; }
        }

        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        public DateTime RecordDate
        {
            get { return recordDate; }
            set { recordDate = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public string RecordType
        {
            get { return recordType; }
            set { recordType = value; }
        }

        // Default constructor
        public FinancialRecord() { }

        // Parametrized constructor
        public FinancialRecord(int recordID, int employeeID, DateTime recordDate, string description, decimal amount, string recordType)
        {
            RecordID = recordID;
            EmployeeID = employeeID;
            RecordDate = recordDate;
            Description = description;
            Amount = amount;
            RecordType = recordType;
        }
    }
}