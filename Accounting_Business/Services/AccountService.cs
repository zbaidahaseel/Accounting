using Accounting_Business.Persistence.Entities;
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
    }
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _context;
        //add update, delete, get by account number, get all accounts
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
            var account = await _context.Accounts.Where(e => e.AccountNumber == "1001")
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

    }
}
