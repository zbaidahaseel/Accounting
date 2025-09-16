namespace Accounting_Business.Persistence.Resources
{
    public class AccountResource
    {
        public string AccountNumber { get; set; }

        public string Name { get; set; }

        public string EnglishName { get; set; }

        public int CurrencyId { get; set; }
      
        public string CurrencyName { get; set; }

        public string? ParentAccountNumber { get; set; }

        public int AccountClassificationId { get; set; }
      
        public string AccountClassificationName { get; set; }

        public int SubAccountClassificationId { get; set; }
     
        public string SubAccountClassificationName { get; set; }

        public int? BudgetItem { get; set; }

        public int Level { get; set; }

        public bool IsActive { get; set; }
    }
}
