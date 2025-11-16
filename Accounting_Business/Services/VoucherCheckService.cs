using Accounting_Business.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Accounting_Business.Services
{
    public interface IVoucherCheckService
    {
        void Add(List<VoucherCheck> voucherChecks);
        void Delete(List<VoucherCheck> voucherChecks);
        Task<List<VoucherCheck>> GetByVoucherId(int voucherId);
    }
    public class VoucherCheckService : IVoucherCheckService
    {
        private readonly AppDbContext _context;
        public VoucherCheckService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(List<VoucherCheck> voucherChecks)
        {
            _context.VoucherChecks.AddRange(voucherChecks);
        }

        public void Delete(List<VoucherCheck> voucherChecks)
        {
            _context.VoucherChecks.RemoveRange(voucherChecks);
        }

        public async Task<List<VoucherCheck>> GetByVoucherId(int voucherId)
        {
            return await _context.VoucherChecks
                .Where(vc => vc.VoucherId == voucherId)
                .ToListAsync();
        }
    }
}
