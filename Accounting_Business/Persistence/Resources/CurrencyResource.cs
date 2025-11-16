namespace Accounting_Business.Persistence.Resources
{
    public class CurrencyResource
    {
        public int Id { get; set; }

        public string IsoCode { get; set; }

        public string Name { get; set; }

        public string Unit { get; set; }

        public decimal? NumberOfUnits { get; set; }
    }
}
