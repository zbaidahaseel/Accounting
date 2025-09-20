using Accounting_Business.Persistence.Entities;

namespace Accounting_Business.Services
{
    public interface IProfileSubAccountService
    {
        void Add(List<ProfileSubAccount> additionalInformation);
        void Update(List<ProfileSubAccount> additionalInformation);
        void Delete(List<ProfileSubAccount> additionalInformation);
        List<ProfileSubAccount> GetAllByProfileCode(string profileCode);
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
        public List<ProfileSubAccount> GetAllByProfileCode(string profileCode)
        {
            return _context.ProfileSubAccounts
                .Where(e => e.ProfileCode == profileCode)
                .ToList();
        }
    }
}
