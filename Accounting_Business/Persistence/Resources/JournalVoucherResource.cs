namespace Accounting_Business.Persistence.Resources
{
    public class JournalVoucherResource
    {
        public int Id { get; set; }

        public DateOnly VoucherDate { get; set; }

        public TimeOnly TimeCreated { get; set; }

        public int CurrencyId { get; set; }

        public decimal ExchangeRate { get; set; }

        public DateOnly TaxDueDate { get; set; }

        public decimal TaxPercentage { get; set; }

        public string ReferenceNumber { get; set; }

        public int AgentId { get; set; }

        public List<JournalVoucherCheckResource> JournalVoucherChecks { get; set; }
    }
}
