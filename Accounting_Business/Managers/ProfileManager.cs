using Accounting_Business.Infrastructure.Responses;
using Accounting_Business.Mappings;
using Accounting_Business.Persistence.Entities;
using Accounting_Business.Persistence.Models;
using Accounting_Business.Persistence.Resources;
using Accounting_Business.Services;
using AutoMapper;

namespace Accounting_Business.Managers
{
    public interface IProfileManager
    {
        Task<Response> AddProfile(ProfileModel profileModel);
        Task<Response> UpdateProfile(ProfileModel profileModel);
        Task<Response> GetProfile(string profileCode);
        Task<Response> DeleteProfile(string profileCode);
        Task<Response> AddEmployee(EmployeeModel employeeModel);
        Task<Response> UpdateEmployee(EmployeeModel employeeModel);
        Task<Response> DeleteEmployee(string employeeCode);
        Task<Response> GetEmployee(string employeeCode);
        Task<Response> GetEmployeesByFilters(EmployeeFilterModel employeeFilter);
    }
    public class ProfileManager : IProfileManager
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IProfileService _profileService;
        private readonly IAdditionalInformationService _additionalInformationService;
        private readonly ProfileSubAccountService _profileSubAccountService;
        private readonly IEmployeeService _employeeService;
        public ProfileManager(AppDbContext context,
            IMapper mapper,
            IProfileService profileService,
            IAdditionalInformationService additionalInformationService,
            ProfileSubAccountService profileSubAccountService,
            IEmployeeService employeeService)
        {
            _context = context;
            _mapper = mapper;
            _profileService = profileService;
            _additionalInformationService = additionalInformationService;
            _profileSubAccountService = profileSubAccountService;
            _employeeService = employeeService;
        }

        public async Task<Response> AddProfile(ProfileModel profileModel)
        {
            var profile = profileModel.ToEntity(_mapper);

            profile.AdditionalInformations = profileModel.AdditionalInformations.Select(e => e.ToEntity()).ToList();

            profile.ProfileSubAccounts = profileModel.SubAccounts.Select(e => e.ToEntity()).ToList();

            _profileService.Add(profile);

            await _context.SaveChangesAsync();
            
            return profile.ProfileCode.ToSuccessResponseWithModel();
        }

        public async Task<Response> UpdateProfile(ProfileModel profileModel)
        {
            var existingProfile = await _profileService.Get(profileModel.ProfileCode);

            existingProfile = profileModel.ToEntity(_mapper, existingProfile);

            _profileService.Update(existingProfile);

            var existingAdditionalInformation = await _additionalInformationService.GetAllByProfileId(existingProfile.Id);

            var existingSubAccounts = await _profileSubAccountService.GetAllByProfileId(existingProfile.Id);

            _additionalInformationService.Delete(existingAdditionalInformation);
            
            _profileSubAccountService.Delete(existingSubAccounts);

            existingProfile.AdditionalInformations = profileModel.AdditionalInformations.Select(e => e.ToEntity()).ToList();

            existingProfile.ProfileSubAccounts = profileModel.SubAccounts.Select(e => e.ToEntity()).ToList();
            
            await _context.SaveChangesAsync();

            return ResponseAction.ToSuccessResponse();
        }

        public async Task<Response> GetProfile(string profileCode)
        {
            var profile = await _profileService.Get(profileCode);
          
            var resource = profile.ToResource(_mapper);

            return resource.ToSuccessResponseWithModel();
        }

        public async Task<Response> DeleteProfile(string profileCode)
        {
            var profile = await _profileService.Get(profileCode);

            var additionalInformation = await _additionalInformationService.GetAllByProfileId(profile.Id);

            var subAccounts = await _profileSubAccountService.GetAllByProfileId(profile.Id);

            _additionalInformationService.Delete(additionalInformation);

            _profileSubAccountService.Delete(subAccounts);

            _profileService.Delete(profile);
            
            await _context.SaveChangesAsync();
            
            return ResponseAction.ToSuccessResponse();
        }

        public async Task<Response> AddEmployee(EmployeeModel employeeModel)
        {
            var employee = employeeModel.ToEntity(_mapper);
           
            _employeeService.Add(employee);
           
            await _context.SaveChangesAsync();
            
            return employee.EmployeeCode.ToSuccessResponseWithModel();
        }

        public async Task<Response> UpdateEmployee(EmployeeModel employeeModel)
        {
            var existingEmployee = await _employeeService.GetByCode(employeeModel.EmployeeCode);
            
            existingEmployee = employeeModel.ToEntity(_mapper, existingEmployee);
          
            _employeeService.Update(existingEmployee);
            
            await _context.SaveChangesAsync();

            
            return ResponseAction.ToSuccessResponse();
        }

        public async Task<Response> DeleteEmployee(string employeeCode)
        {
            var employee = await _employeeService.GetByCode(employeeCode);

            _employeeService.Delete(employee);

            await _context.SaveChangesAsync();
            
            return ResponseAction.ToSuccessResponse();
        }

        public async Task<Response> GetEmployee(string employeeCode)
        {
            var employee = await _employeeService.GetByCode(employeeCode);

            var resource = employee.ToResource(_mapper);

            return resource.ToSuccessResponseWithModel();
        }

        public async Task<Response> GetEmployeesByFilters(EmployeeFilterModel employeeFilter)
        {
            var employees = await _employeeService.GetEmployeesByFilters(employeeFilter);
           
            var resources = _mapper.Map<List<Employee>, List<EmployeeResource>>(employees);
            
            return resources.ToSuccessResponseWithModel();
        }
    }
}
