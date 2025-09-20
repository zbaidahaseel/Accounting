using Accounting_Business.Infrastructure.Responses;
using Accounting_Business.Mappings;
using Accounting_Business.Persistence.Entities;
using Accounting_Business.Persistence.Models;
using Accounting_Business.Services;
using AutoMapper;

namespace Accounting_Business.Managers
{
    public interface IProfileManager
    {
        Task<Response> AddProfile(ProfileModel profileModel);
        Task<Response> UpdateProfile(ProfileModel profileModel);
        Task<Response> DeleteProfile(string profileCode);
    }
    public class ProfileManager : IProfileManager
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IProfileService _profileService;
        private readonly IAdditionalInformationService _additionalInformationService;
        private readonly ProfileSubAccountService _profileSubAccountService;
        public ProfileManager(AppDbContext context,
            IMapper mapper,
            IProfileService profileService,
            IAdditionalInformationService additionalInformationService,
            ProfileSubAccountService profileSubAccountService)
        {
            _context = context;
            _mapper = mapper;
            _profileService = profileService;
            _additionalInformationService = additionalInformationService;
            _profileSubAccountService = profileSubAccountService;
        }

        public async Task<Response> AddProfile(ProfileModel profileModel)
        {
            var profile = profileModel.ToEntity(_mapper);

            var additionalInformation = profileModel.AdditionalInformations.Select(e => e.ToEntity()).ToList();

            _additionalInformationService.Add(additionalInformation);

            var subAccounts = profileModel.SubAccounts.Select(e => e.ToEntity()).ToList();

            _profileSubAccountService.Add(subAccounts);

            profile.AdditionalInformations = additionalInformation;

            profile.ProfileSubAccounts = subAccounts;
            
            _profileService.Add(profile);

            await _context.SaveChangesAsync();
            
            return profile.ProfileCode.ToSuccessResponseWithModel();
        }

        public async Task<Response> UpdateProfile(ProfileModel profileModel)
        {
            var profile = profileModel.ToEntity(_mapper);

            var additionalInformation = profileModel.AdditionalInformations.Select(e => e.ToEntity()).ToList();
         
            _additionalInformationService.Update(additionalInformation);
            
            var subAccounts = profileModel.SubAccounts.Select(e => e.ToEntity()).ToList();
            
            _profileSubAccountService.Update(subAccounts);

            _profileService.Update(profile);

            await _context.SaveChangesAsync();

            return ResponseAction.ToSuccessResponse();
        }

        public async Task<Response> DeleteProfile(string profileCode)
        {
            var profile = await _profileService.Get(profileCode);

            var additionalInformation = _additionalInformationService.GetAllByProfileCode(profileCode);

            var subAccounts = _profileSubAccountService.GetAllByProfileCode(profileCode);

            _additionalInformationService.Delete(additionalInformation);

            _profileSubAccountService.Delete(subAccounts);

            _profileService.Delete(profile);
            
            await _context.SaveChangesAsync();
            
            return ResponseAction.ToSuccessResponse();
        }
    }
}
