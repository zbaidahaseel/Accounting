using Accounting_Business.Persistence.Entities;

namespace Accounting_Business.Services
{
    public interface IAdditionalInformationService
    {
        void Add(List<AdditionalInformation> additionalInformation);
        void Update(List<AdditionalInformation> additionalInformation);
        void Delete(List<AdditionalInformation> additionalInformation);
        List<AdditionalInformation> GetAllByProfileCode(string profileCode);
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
        public List<AdditionalInformation> GetAllByProfileCode(string profileCode)
        {
            return _context.AdditionalInformations
                .Where(e => e.ProfileCode == profileCode)
                .ToList();
        }
    }
}
