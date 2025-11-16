namespace Accounting_Business.Persistence.Resources
{
    public class ExchangeCurrencyResource
    {
        public int Id { get; set; }
        public int CurrencyId { get; set; }

        public int BaseCurrencyId { get; set; }

        public decimal BuyPrice { get; set; }

        public decimal SellPrice { get; set; }

        public DateOnly EffectiveDate { get; set; }
    }
}
