namespace Accounting_Business.Persistence.Models
{
    public class VoucherCheckModel
    {
        public int? Id { get; set; }

        public int? VoucherId { get; set; }

        public int CheckNo { get; set; }

        public int BankId { get; set; }

        public int AccountId { get; set; }

        public DateOnly DueDate { get; set; }

        public decimal Amount { get; set; }
    }
}
