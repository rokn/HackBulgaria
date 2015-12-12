using System;
using System.Collections.Generic;

namespace VatTax
{
    public class VATTaxCalculator
    {
        private List<CountryVatTax> countries;
        private int defaultCountryId;

        /// <summary>
        /// Create a new VATTaxCalculator
        /// </summary>
        /// <param name="countries">The list of supported countries</param>
        /// <param name="defaultId">The id of the default country</param>
        public VATTaxCalculator(List<CountryVatTax> countries)
        {
            this.countries = countries;

            foreach (var country in countries)
            {
                if(country.IsDefault)
                {
                    defaultCountryId = country.CountryID;
                    break;
                }
            }
        }


        /// <summary>
        /// Calculates the VATTax for a price in given country
        /// </summary>
        /// <param name="productPrice">The price of the product</param>
        /// <param name="countryId">The id of the country</param>
        /// <returns>The price with applied VATTax</returns>
        public double CalculateTax(double productPrice, int countryId)
        {
            int? vatTax = null;

            foreach (var country in countries)
            {
                if(country.CountryID == countryId)
                {
                    vatTax = country.VATTax;
                }
            }

            if(vatTax == null)
            {
                throw new Exception("Country ID : " + countryId + " is not supported.");
            }

            return productPrice + productPrice * (int)vatTax / 100;
        }

        public double CalculateTax(double productPrice)
        {
            return CalculateTax(productPrice, defaultCountryId);
        }
    }
}
