namespace Accounting_Business.Persistence.Models
{
    public class AccountFilterModel
    {
        public string? AccountNumber { get; set; }
        public string? Name { get; set; }
        public int? Level { get; set; }
        public string? ParentAccountNumber { get; set; }
        public string? ParentAccountName { get; set; }
        public int? AccountClassification { get; set; }
        public int? BudgetItem { get; set; }
    }
}
