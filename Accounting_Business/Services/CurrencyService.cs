using Accounting_Business.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Accounting_Business.Services
{
    public interface ICurrencyService
    {
        void Add(Currency currency);
        void Update(Currency currency);
        void Delete(Currency currency);
        Task<Currency> Get(int id);
        Task<List<Currency>> GetAll();
    }
    public class CurrencyService : ICurrencyService
    {
        private readonly AppDbContext _context;
        public CurrencyService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Currency currency)
        {
            _context.Currencies.Add(currency);
        }

        public void Update(Currency currency)
        {
            _context.Currencies.Update(currency);
        }

        public void Delete(Currency currency)
        {
            _context.Currencies.Remove(currency);
        }

        public async Task<Currency> Get(int id)
        {
            var currency = await _context.Currencies.FindAsync(id);
            return currency;
        }

        public async Task<List<Currency>> GetAll()
        {
            var currencies = await _context.Currencies.ToListAsync();
            return currencies;
        }
    }
}
