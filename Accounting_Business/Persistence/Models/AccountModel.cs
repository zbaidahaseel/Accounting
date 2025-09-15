using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_Business.Persistence.Models
{
    public class AccountModel
    {
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public int CurrencyId { get; set; }
        public string ParentAccountNumber { get; set; }
        public int AccountClassificationId { get; set; }
        public int SubAccountClassificationId { get; set; }
        public int BudgetItem { get; set; }
        public int Level { get; set; }
        public bool? IsActive { get; set; }
    }
}
