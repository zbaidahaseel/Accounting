using Accounting_Business.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Accounting_Business.Services
{
    public interface IVoucherService
    {
        void Add(Voucher voucher);
        void Update(Voucher voucher);
        void Delete(Voucher voucher);
        Task<Voucher> GetById(int id);
        Task<List<Voucher>> GetAll();
    }
    public class VoucherService : IVoucherService
    {
        private readonly AppDbContext _context;
        public VoucherService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Voucher voucher)
        {
            _context.Vouchers.Add(voucher);
        }

        public void Update(Voucher voucher)
        {
            _context.Vouchers.Update(voucher);
        }

        public void Delete(Voucher voucher)
        {
            _context.Vouchers.Remove(voucher);
        }

        public async Task<Voucher> GetById(int id)
        {
            return await _context.Vouchers.FindAsync(id);
        }

        public async Task<List<Voucher>> GetAll()
        {
            return await _context.Vouchers.ToListAsync();
        }   
    }
}
