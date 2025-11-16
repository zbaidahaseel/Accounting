using Accounting_Business.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Accounting_Business.Services
{
    public interface IExchangeCurrencyService
    {
        void Add(ExchangeCurrency exchangeCurrency);
        void Update(ExchangeCurrency exchangeCurrency);
        void Remove(ExchangeCurrency exchangeCurrency);
        Task<ExchangeCurrency> GetById(int id);
        Task<List<ExchangeCurrency>> GetAll();
    }
    public class ExchangeCurrencyService: IExchangeCurrencyService
    {
        private readonly AppDbContext _context;
        public ExchangeCurrencyService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(ExchangeCurrency exchangeCurrency)
        {
            _context.ExchangeCurrencies.Add(exchangeCurrency);
        }

        public void Update(ExchangeCurrency exchangeCurrency)
        {
            _context.ExchangeCurrencies.Update(exchangeCurrency);
        }

        public void Remove(ExchangeCurrency exchangeCurrency) 
        {
            _context.ExchangeCurrencies.Remove(exchangeCurrency);
        }

        public async Task<ExchangeCurrency> GetById(int id)
        {
            var exchangeCurrency = await _context.ExchangeCurrencies.FindAsync(id);
            return exchangeCurrency;
        }

        public async Task<List<ExchangeCurrency>> GetAll()
        {
            var exchangeCurrencies = await _context.ExchangeCurrencies.ToListAsync();
            return exchangeCurrencies;
        }

    }
}
