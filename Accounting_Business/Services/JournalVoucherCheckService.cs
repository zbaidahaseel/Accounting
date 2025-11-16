using Accounting_Business.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Accounting_Business.Services
{
    public interface IJournalVoucherCheckService
    {
        void Add(List<JournalVoucherCheck> voucherChecks);
        void Delete(List<JournalVoucherCheck> voucherChecks);
        Task<List<JournalVoucherCheck>> GetByVoucherId(int voucherId);
    }
    public class JournalVoucherCheckService : IJournalVoucherCheckService
    {
        private readonly AppDbContext _context;
        public JournalVoucherCheckService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(List<JournalVoucherCheck> voucherChecks)
        {
            _context.JournalVoucherChecks.AddRange(voucherChecks);
        }

        public void Delete(List<JournalVoucherCheck> voucherChecks)
        {
            _context.JournalVoucherChecks.RemoveRange(voucherChecks);
        }

        public async Task<List<JournalVoucherCheck>> GetByVoucherId(int voucherId)
        {
            return await _context.JournalVoucherChecks
                .Where(vc => vc.VoucherId == voucherId)
                .ToListAsync();
        }
    }
}
