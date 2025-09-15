using Accounting_Business.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Accounting_Business.Services
{
    public interface ICostCenterService
    {
        void Add(CostCenter costCenter);
        void Delete(CostCenter costCenter);
        Task<CostCenter> Get(int id);
        Task<List<CostCenter>> GetAll();
    }
    public class CostCenterService : ICostCenterService
    {
        private readonly AppDbContext _context;
        public CostCenterService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(CostCenter costCenter)
        {
            _context.CostCenters.Add(costCenter);
        }

        public void Delete(CostCenter costCenter)
        {
            _context.CostCenters.Remove(costCenter);
        }

        public async Task<CostCenter> Get(int id)
        {
            var costCenter = await _context.CostCenters.FindAsync(id);
            // if (costCenters == null) { throw new NotFo}
            return costCenter;
        }
        public async Task<List<CostCenter>> GetAll()
        {
            var costCenters = await _context.CostCenters.Where(e => e.IsActive == true).ToListAsync();
            return costCenters;
        }

    }
}
