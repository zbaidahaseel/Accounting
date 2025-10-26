namespace Accounting_Business.Persistence.Resources
{
    public class ChartOfAccountResource
    {
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public int Level { get; set; }
        public string? ParentAccountNumber { get; set; }
        public string? ParentAccountName { get; set; }
        public string AccountClassificationName { get; set; }
        public int? BudgetItem { get; set; }
    }
}
