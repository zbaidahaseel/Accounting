namespace Accounting_Business.Persistence.Resources
{
    public class VoucherResource
    {
        public int? Id { get; set; }

        public DateOnly VoucherDate { get; set; }

        public TimeOnly TimeCreated { get; set; }

        public int CurrencyId { get; set; }

        public decimal ExchangeRate { get; set; }

        public decimal AmountPayment { get; set; }

        public decimal CashAmountPayment { get; set; }

        public decimal CheckAmountPayment { get; set; }

        public int CashAccountTo { get; set; }

        public int CheckAccountTo { get; set; }

        public int AccountFrom { get; set; }

        public string AccountFromName { get; set; }

        public int AgentId { get; set; }

        public string SubAccount { get; set; }

        public string ReferenceNumber { get; set; }

        public decimal Discount { get; set; }

        public string Description { get; set; }

        public decimal TotalAmount { get; set; }

        public int VoucherTypeId { get; set; }

        public List<VoucherCheckResource> VoucherChecks { get; set; }
    }
}
