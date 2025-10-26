using Accounting_Business.Persistence.Entities;
using Accounting_Business.Persistence.Models;
using Accounting_Business.Persistence.Resources;
using AutoMapper;
using Profile = Accounting_Business.Persistence.Entities.Profile;

namespace Accounting_Business.Mappings
{
    public static class ProfileMapping
    {
        public static Profile ToEntity(this ProfileModel model, IMapper mapper, Profile? profile = null)
        {
            if (model == null) return null;

            if(profile != null)
            {
               return mapper.Map(model, profile);
            }

            return mapper.Map<ProfileModel, Profile>(model);
        }

        public static AdditionalInformation ToEntity(this AdditionalInformationModel model)
        {
            return new AdditionalInformation
            {
                Name = model.Name,
            };
        }

        public static ProfileSubAccount ToEntity(this SubAccountModel model)
        {
            return new ProfileSubAccount
            {
                Name = model.Name,
            };
        }

        public static Employee ToEntity(this EmployeeModel employeeModel, IMapper mapper, Employee? employee = null)
        {
            if (employeeModel == null) return null;

            if (employee != null)
            {
                return mapper.Map(employeeModel, employee);
            }
            return mapper.Map<EmployeeModel, Employee>(employeeModel);
        }

        public static EmployeeResource ToResource(this Employee employee, IMapper mapper)
        {
            if (employee == null) return null;

            var resource = mapper.Map<Employee, EmployeeResource>(employee);
            resource.ClassificationName = employee.Classification?.Name;
            resource.GenderName = employee.Gender?.Name;
            resource.MaritalStatusName = employee.MaritalStatus?.Name;

            return resource;
        }

        public static ProfileResource ToResource(this Profile profile, IMapper mapper)
        {
            if (profile == null) return null;

            var resource = mapper.Map<Profile, ProfileResource>(profile);

            resource.CityName = profile.City?.Name;
            resource.ClassificationName = profile.Classification?.Name;
            resource.CurrencyName = profile.Currency?.Name;
            resource.AgentName = profile.Agent?.Name;

            return resource;
        }

        public static AdditionalInformationResource ToResource(this AdditionalInformation entity, IMapper mapper)
        {
            if (entity == null) return null;

            var resource = mapper.Map<AdditionalInformation, AdditionalInformationResource>(entity);

            return resource;
        }

        public static ProfileSubAccountResource ToResource(this ProfileSubAccount entity, IMapper mapper)
        {
            if (entity == null) return null;

            var resource = mapper.Map<ProfileSubAccount, ProfileSubAccountResource>(entity);

            return resource;
        }
    }
}
