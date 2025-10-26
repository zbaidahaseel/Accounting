using Accounting_Business.Persistence.Entities;
using Accounting_Business.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Accounting_Business.Services
{
    public interface IAccountService
    {
        void Add(Account account);
        void Update(Account account);
        void Delete(Account account);
        Task<Account> Get(string accountNumber);
        Task<List<Account>> GetAll();
        Task<List<Account>> GetChartOfAccounts(AccountFilterModel accountFilterModel);

    }
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _context;
        public AccountService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Account account)
        {
            _context.Accounts.Add(account);
        }

        public void Update(Account account)
        {
            _context.Accounts.Update(account);
        }

        public async Task<Account> Get(string accountNumber)
        {
            var account = await _context.Accounts.Where(e => e.AccountNumber == accountNumber)
                        .Include(q => q.Currency)
                        .Include(q => q.AccountClassification)
                        .Include(q => q.SubAccountClassification)
                        .Include(q => q.InverseParentAccountNumberNavigation)
                        .Include(q => q.ParentAccountNumberNavigation)
                        .FirstOrDefaultAsync();
            ;
            // if (accounts == null) { throw new NotFo}
            return account;
        }

        public void Delete(Account account)
        {
            _context.Accounts.Remove(account);
        }

        public async Task<List<Account>> GetAll()
        {
            var accounts = await _context.Accounts.Where(e => e.IsActive == true)
                .Include(q => q.Currency)
                .ToListAsync();
            return accounts;
        }

        public async Task<List<Account>> GetChartOfAccounts(AccountFilterModel accountFilterModel)
        {
            var query = _context.Accounts.AsQueryable();

            if (!string.IsNullOrWhiteSpace(accountFilterModel.AccountNumber))
                query = query.Where(a => a.AccountNumber == accountFilterModel.AccountNumber);

            if (!string.IsNullOrWhiteSpace(accountFilterModel.Name))
                query = query.Where(a => a.Name == accountFilterModel.Name);

            if (accountFilterModel.Level.HasValue)
                query = query.Where(a => a.Level == accountFilterModel.Level.Value);

            if (!string.IsNullOrWhiteSpace(accountFilterModel.ParentAccountNumber))
                query = query.Where(a => a.ParentAccountNumber == accountFilterModel.ParentAccountNumber);

            if (accountFilterModel.AccountClassification.HasValue)
                query = query.Where(a => a.AccountClassificationId == accountFilterModel.AccountClassification.Value);

            if (accountFilterModel.BudgetItem.HasValue)
                query = query.Where(a => a.BudgetItem == accountFilterModel.BudgetItem.Value);

            return await query
                .Include(q => q.AccountClassification)
                .Include(q => q.ParentAccountNumberNavigation)
                .ToListAsync();
        }
        

    }
}
