using Accounting_Business.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Accounting_Business.Services
{
    public interface IReceivablesPayablesClassificationService
    {
        void Add(ReceivablesPayablesClassification receivablesPayablesClassification);
        void Delete(ReceivablesPayablesClassification receivablesPayablesClassification);
        Task<ReceivablesPayablesClassification> Get(int id);
        Task<List<ReceivablesPayablesClassification>> GetAll();
    }
    public class ReceivablesPayablesClassificationService : IReceivablesPayablesClassificationService
    {
        private readonly AppDbContext _context;
        public ReceivablesPayablesClassificationService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(ReceivablesPayablesClassification receivablesPayablesClassification)
        {
            _context.ReceivablesPayablesClassifications.Add(receivablesPayablesClassification);
        }

        public void Delete(ReceivablesPayablesClassification receivablesPayablesClassification)
        {
            _context.ReceivablesPayablesClassifications.Remove(receivablesPayablesClassification);
        }

        public async Task<ReceivablesPayablesClassification> Get(int id)
        {
            var receivablesPayablesClassification = await _context.ReceivablesPayablesClassifications.FindAsync(id);
            // if (receivablesPayablesClassifications == null) { throw new NotFo}
            return receivablesPayablesClassification;
        }
        public async Task<List<ReceivablesPayablesClassification>> GetAll()
        {
            var receivablesPayablesClassifications = await _context.ReceivablesPayablesClassifications.Where(e => e.IsActive == true).ToListAsync();
            return receivablesPayablesClassifications;
        }
    }
}
