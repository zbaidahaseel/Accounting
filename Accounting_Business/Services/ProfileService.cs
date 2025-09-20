using Accounting_Business.Persistence.Entities;

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
           return await _context.Profiles.FindAsync(profileCode);
        }

        public void Delete(Profile profile)
        {
            _context.Profiles.Remove(profile);
        }
    }
}
