using Accounting_Business.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Accounting_Business.Services
{
    public interface IJournalVoucherService
    {
        void Add(JournalVoucher voucher);
        void Update(JournalVoucher voucher);
        void Delete(JournalVoucher voucher);
        Task<JournalVoucher> GetById(int id);
        Task<List<JournalVoucher>> GetAll();
    }
    public class JournalVoucherService : IJournalVoucherService
    {
        private readonly AppDbContext _context;
        public JournalVoucherService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(JournalVoucher voucher)
        {
            _context.JournalVouchers.Add(voucher);
        }

        public void Update(JournalVoucher voucher)
        {
            _context.JournalVouchers.Update(voucher);
        }

        public void Delete(JournalVoucher voucher)
        {
            _context.JournalVouchers.Remove(voucher);
        }

        public async Task<JournalVoucher> GetById(int id)
        {
            return await _context.JournalVouchers.FindAsync(id);
        }

        public async Task<List<JournalVoucher>> GetAll()
        {
            return await _context.JournalVouchers.ToListAsync();
        }
    }
}
