namespace VatTax
{
    public struct CountryVatTax
    {
        /// <summary>
        /// The ID of the country
        /// </summary>
        public int CountryID { get; set; }

        /// <summary>
        /// The VATTax in per cents
        /// </summary>
        public int VATTax { get; set; }

        /// <summary>
        /// Is this the default country
        /// </summary>
        public bool IsDefault { get; set; }

        public CountryVatTax(int id, int vatTax, bool isDefault)
        {
            CountryID = id;
            VATTax = vatTax;
            IsDefault = isDefault;
        }
    }
}
