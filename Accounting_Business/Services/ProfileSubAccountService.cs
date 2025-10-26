using Accounting_Business.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Accounting_Business.Services
{
    public interface IProfileSubAccountService
    {
        void Add(List<ProfileSubAccount> additionalInformation);
        void Update(List<ProfileSubAccount> additionalInformation);
        void Delete(List<ProfileSubAccount> additionalInformation);
        Task<List<ProfileSubAccount>> GetAllByProfileId(int profileId);
    }
    public class ProfileSubAccountService : IProfileSubAccountService
    {
        private readonly AppDbContext _context;
        public ProfileSubAccountService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(List<ProfileSubAccount> additionalInformation)
        {
            _context.ProfileSubAccounts.AddRange(additionalInformation);
        }
        public void Update(List<ProfileSubAccount> additionalInformation)
        {
            _context.ProfileSubAccounts.UpdateRange(additionalInformation);
        }

        public void Delete(List<ProfileSubAccount> additionalInformation)
        {
            _context.ProfileSubAccounts.RemoveRange(additionalInformation);
        }
        public async Task<List<ProfileSubAccount>> GetAllByProfileId(int profileId)
        {
            return await _context.ProfileSubAccounts
                .Where(e => e.ProfileId == profileId)
                .ToListAsync();
        }
    }
}
