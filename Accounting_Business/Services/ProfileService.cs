using Accounting_Business.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Accounting_Business.Services
{
    public interface IProfileService
    {
        void Add(Profile profile);
        void Update(Profile profile);
        void Delete(Profile profile);
        Task<Profile> Get(string profileCode);
    }
    public class ProfileService : IProfileService
    {
        private readonly AppDbContext _context;
        public ProfileService(AppDbContext context) 
        {
            _context = context;
        }

        public void Add(Profile profile)
        {
            _context.Profiles.Add(profile);
        }

        public void Update(Profile profile)
        {
            _context.Profiles.Update(profile);
        }

        public async Task<Profile> Get(string profileCode)
        {
           return await _context.Profiles
                .Include(e => e.AdditionalInformations)
                .Include(e => e.ProfileSubAccounts)
                .Include(e => e.Currency)
                .Include(e => e.Classification)
                .Include(e => e.City)
                .Include(e => e.Agent)
                .SingleOrDefaultAsync(e => e.ProfileCode == profileCode);
        }

        public void Delete(Profile profile)
        {
            _context.Profiles.Remove(profile);
        }
    }
}
