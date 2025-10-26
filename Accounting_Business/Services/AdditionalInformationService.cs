using Accounting_Business.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Accounting_Business.Services
{
    public interface IAdditionalInformationService
    {
        void Add(List<AdditionalInformation> additionalInformation);
        void Update(List<AdditionalInformation> additionalInformation);
        void Delete(List<AdditionalInformation> additionalInformation);
        Task<List<AdditionalInformation>> GetAllByProfileId(int profileId);
    }
    public class AdditionalInformationService : IAdditionalInformationService
    {
        private readonly AppDbContext _context;
        public AdditionalInformationService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(List<AdditionalInformation> additionalInformation)
        {
            _context.AdditionalInformations.AddRange(additionalInformation);
        }
        public void Update(List<AdditionalInformation> additionalInformation)
        {
            _context.AdditionalInformations.UpdateRange(additionalInformation);
        }

        public void Delete(List<AdditionalInformation> additionalInformation)
        {
            _context.AdditionalInformations.RemoveRange(additionalInformation);
        }
        public async Task<List<AdditionalInformation>> GetAllByProfileId(int profileId)
        {
            return await _context.AdditionalInformations
                .Where(e => e.ProfileId == profileId)
                .ToListAsync();
        }
    }
}
