using PayXpert.Model;
using PayXpert.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Service
{
    internal class TaxService : ITaxService
    {
        private TaxRepository _taxRepository;

        public TaxService()
        {
            _taxRepository = new TaxRepository();
        }

        public void CalculateTax(int employeeId, int taxYear)
        {
            try
            {
                decimal taxAmount = _taxRepository.CalculateTax(employeeId, taxYear);

                if (taxAmount > 0)
                {
                    Console.WriteLine($"The calculated tax for Employee ID {employeeId} for the year {taxYear} is: {taxAmount:C}");
                }
                else
                {
                    Console.WriteLine($"No tax applicable for Employee ID {employeeId} for the year {taxYear}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error calculating tax: " + ex.Message);
            }
        }

        public void GetTaxById(int taxId)
        {
            try
            {
                Tax tax = _taxRepository.GetTaxById(taxId);

                if (tax == null)
                {
                    Console.WriteLine($"No tax record found with Tax ID: {taxId}");
                }
                else
                {
                    Console.WriteLine($"Tax ID: {tax.TaxID}, Employee ID: {tax.EmployeeID}, Tax Year: {tax.TaxYear}, " +
                        $"Taxable Income: {tax.TaxableIncome}, Tax Amount: {tax.TaxAmount}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving tax details: " + ex.Message);
            }
        }

        public void GetTaxesForEmployee(int employeeId)
        {
            try
            {
                List<Tax> taxes = _taxRepository.GetTaxesForEmployee(employeeId);

                if (taxes.Count == 0)
                {
                    Console.WriteLine($"No tax records found for Employee ID: {employeeId}");
                }
                else
                {
                    Console.WriteLine($"Tax records for Employee ID: {employeeId}");
                    foreach (var tax in taxes)
                    {
                        Console.WriteLine($"Tax ID: {tax.TaxID}, Tax Year: {tax.TaxYear}, " +
                            $"Taxable Income: {tax.TaxableIncome}, Tax Amount: {tax.TaxAmount}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving taxes for employee: " + ex.Message);
            }
        }

        public void GetTaxesForYear(int taxYear)
        {
            try
            {
                List<Tax> taxes = _taxRepository.GetTaxesForYear(taxYear);

                if (taxes.Count == 0)
                {
                    Console.WriteLine($"No tax records found for the year: {taxYear}");
                }
                else
                {
                    Console.WriteLine($"Tax records for the year: {taxYear}");
                    foreach (var tax in taxes)
                    {
                        Console.WriteLine($"Tax ID: {tax.TaxID}, Employee ID: {tax.EmployeeID}, " +
                            $"Taxable Income: {tax.TaxableIncome}, Tax Amount: {tax.TaxAmount}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving taxes for year: " + ex.Message);
            }
        }
    }
}
