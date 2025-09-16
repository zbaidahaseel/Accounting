using Accounting_Business.Persistence.Entities;
using Accounting_Business.Persistence.Models;
using Accounting_Business.Persistence.Resources;
using AutoMapper;

namespace Accounting_Business.Mappings
{
    public class MasterDataMapper : Profile
    {
        public MasterDataMapper()
        {
            CreateMap<AccountModel, Account>();
            CreateMap<Account, AccountResource>();
        }
    }
}
