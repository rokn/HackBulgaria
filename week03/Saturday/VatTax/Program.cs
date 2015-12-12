using System;
using System.Collections.Generic;

namespace VatTax
{
    class Program
    {
        static void Main(string[] args)
        {
            CountryVatTax c1 = new CountryVatTax(11,15,false);
            CountryVatTax c2 = new CountryVatTax(12,20,true);
            CountryVatTax c3 = new CountryVatTax(13,1,false);
            CountryVatTax c4 = new CountryVatTax(14,200,false);
            CountryVatTax c5= new CountryVatTax(15,50,false);

            List<CountryVatTax> countries = new List<CountryVatTax>();
            countries.Add(c1);
            countries.Add(c2);
            countries.Add(c3);
            countries.Add(c4);
            countries.Add(c5);

            VATTaxCalculator calculator = new VATTaxCalculator(countries);

            Console.WriteLine(calculator.CalculateTax(10,14));
        }
    }
}
