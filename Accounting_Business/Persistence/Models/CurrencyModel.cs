namespace Accounting_Business.Persistence.Models
{
    public class CurrencyModel
    {
        public int? Id { get; set; }
        public string? IsoCode { get; set; }
        public string? Name { get; set; }
        public string? Unit { get; set; }
        public double? NumberOfUnits { get; set; }
        public int? DisplayOrder { get; set; }
    }
}
