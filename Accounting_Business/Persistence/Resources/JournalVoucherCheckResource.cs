namespace Accounting_Business.Persistence.Resources
{
    public class JournalVoucherCheckResource
    {
        public int VoucherId { get; set; }

        public int AccountId { get; set; }

        public string AccountName { get; set; }

        public string SubAccount { get; set; }

        public decimal DebitAmount { get; set; }

        public decimal CreditAmount { get; set; }

        public string Description { get; set; }
    }
}
