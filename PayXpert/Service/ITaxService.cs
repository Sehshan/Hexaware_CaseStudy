using PayXpert.Model;

namespace PayXpert.Service
{
    internal interface ITaxService
    {
        void CalculateTax(int employeeId, int taxYear);

        public void GetTaxById(int taxId);

        public void GetTaxesForEmployee(int employeeId);

        public void GetTaxesForYear(int taxYear);

    }
}
