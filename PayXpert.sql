CREATE DATABASE PayXpert ;
use PayXpert ;

-- Create Employee Table
CREATE TABLE Employee (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Gender VARCHAR(10),
    Email VARCHAR(100) NOT NULL UNIQUE,
    PhoneNumber VARCHAR(15) NOT NULL,
    [Address] VARCHAR(255),
    Position VARCHAR(50),
    JoiningDate DATE NOT NULL,
    TerminationDate DATE NULL
);

SELECT * FROM Employee ;

-- Create Payroll Table
CREATE TABLE Payroll (
    PayrollID INT PRIMARY KEY,
    EmployeeID INT FOREIGN KEY REFERENCES Employee(EmployeeID),
    PayPeriodStartDate DATE NOT NULL,
    PayPeriodEndDate DATE NOT NULL,
    BasicSalary DECIMAL(10, 2) NOT NULL,
    OvertimePay DECIMAL(10, 2) DEFAULT 0,
    Deductions DECIMAL(10, 2) DEFAULT 0,
    NetSalary AS (BasicSalary + OvertimePay - Deductions) 
);
select * from Payroll ;
-- Create Tax Table
CREATE TABLE Tax (
    TaxID INT PRIMARY KEY,
    EmployeeID INT FOREIGN KEY REFERENCES Employee(EmployeeID),
    TaxYear INT NOT NULL,
    TaxableIncome DECIMAL(12, 2) NOT NULL,
    TaxAmount DECIMAL(12, 2) NOT NULL
);
select * from Tax ;

-- Create FinancialRecord Table
CREATE TABLE FinancialRecord (
    RecordID INT PRIMARY KEY,
    EmployeeID INT FOREIGN KEY REFERENCES Employee(EmployeeID),
    RecordDate DATE NOT NULL,
    Description VARCHAR(255),
    Amount DECIMAL(12, 2) NOT NULL,
    RecordType VARCHAR(50) CHECK (RecordType IN ('Income', 'Expense', 'Tax Payment', 'Other'))
);
select * from FinancialRecord ;

INSERT INTO Employee (EmployeeID, FirstName, LastName, DateOfBirth, Gender, Email, PhoneNumber, Address, Position, JoiningDate, TerminationDate)
VALUES 
(1, 'John', 'Doe', '1985-05-15', 'Male', 'john.doe@example.com', '123-456-7890', '123 Main St', 'Software Engineer', '2020-01-10', NULL),
(2, 'Jane', 'Smith', '1990-07-20', 'Female', 'jane.smith@example.com', '987-654-3210', '456 Oak St', 'Developer', '2021-06-01', NULL),
(3, 'Mike', 'Johnson', '1982-11-10', 'Male', 'mike.johnson@example.com', '111-222-3333', '789 Pine St', 'Project Manager', '2019-03-05', '2023-04-15');

INSERT INTO Payroll (PayrollID, EmployeeID, PayPeriodStartDate, PayPeriodEndDate, BasicSalary, OvertimePay, Deductions)
VALUES 
(1, 1, '2023-01-01', '2023-01-31', 5000.00, 200.00, 50.00),
(2, 2, '2023-02-01', '2023-02-28', 4500.00, 150.00, 40.00),
(3, 3, '2023-03-01', '2023-03-31', 6000.00, 300.00, 100.00);

INSERT INTO Tax (TaxID, EmployeeID, TaxYear, TaxableIncome, TaxAmount)
VALUES 
(1, 1, 2023, 50000.00, 5000.00),
(2, 2, 2023, 45000.00, 4500.00),
(3, 3, 2023, 60000.00, 6000.00);

INSERT INTO FinancialRecord (RecordID, EmployeeID, RecordDate, Description, Amount, RecordType)
VALUES 
(1, 1, '2023-01-01', 'Salary Payment', 5000.00, 'Income'),
(2, 2, '2023-02-01', 'Salary Payment', 4500.00, 'Income'),
(3, 3, '2023-03-01', 'Salary Payment', 6000.00, 'Income');
