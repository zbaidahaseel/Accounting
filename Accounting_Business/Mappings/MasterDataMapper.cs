using Accounting_Business.Persistence.Entities;
using Accounting_Business.Persistence.Models;
using Accounting_Business.Persistence.Resources;

namespace Accounting_Business.Mappings
{
    public class MasterDataMapper : AutoMapper.Profile
    {
        public MasterDataMapper()
        {
            CreateMap<AccountModel, Account>();
            CreateMap<Account, AccountResource>();
            CreateMap<Account, ChartOfAccountResource>();
            CreateMap<ProfileModel, Persistence.Entities.Profile>();
            CreateMap<AdditionalInformationModel, AdditionalInformation>();
            CreateMap<SubAccountModel, ProfileSubAccount>();
            CreateMap<EmployeeModel, Employee>();
            CreateMap<Employee, EmployeeResource>();
            CreateMap<Profile,  ProfileResource>(); 
            CreateMap<Employee, EmployeeResource>();
            CreateMap<CurrencyModel, Currency>();
            CreateMap<Currency, CurrencyResource>();                                       
            CreateMap<ExchangeCurrency, ExchangeCurrencyResource>();
            CreateMap<ExchangeCurrencyModel, ExchangeCurrency>();
        }
    }
}
