using Accounting_Business.Persistence.Entities;
using Accounting_Business.Persistence.Models;
using Accounting_Business.Persistence.Resources;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Accounting_Business.Mappings
{
    public static class MasterDataMapping
    {
        public static City ToEntity(this CityModel model)
        {
            if (model == null) return null;
            return new City
            {
                Name = model.Name,              
            };
        }

        public static CostCenter ToEntity(this CostCenterModel model)
        {
            if (model == null) return null;
            return new CostCenter
            {
                Name = model.Name,
            };
        }

        public static Agent ToEntity(this AgentModel model)
        {
            if (model == null) return null;
            return new Agent
            {
                Name = model.Name,
            };
        }

        public static ReceivablesPayablesClassification ToEntity(this ReceivablesPayablesClassificationModel model)
        {
            if (model == null) return null;
            return new ReceivablesPayablesClassification
            {
                Name = model.Name,
            };
        }

        public static Account ToEntity(this AccountModel model, IMapper mapper )
        {
            if (model == null) return null;
            return mapper.Map<AccountModel, Account>(model);
        }

        public static AccountResource ToResource(this Account entity, IMapper mapper)
        {
            if (entity == null) return null;
            var resource = mapper.Map<Account, AccountResource>(entity);
            resource.CurrencyName = entity.Currency?.Name;
            resource.AccountClassificationName = entity.AccountClassification?.Name;
            resource.SubAccountClassificationName = entity.SubAccountClassification?.Name;
            return resource;
        }

        public static ParentAccountResource ToParentResources(this Account entity)
        {
            if (entity == null) return null;
          
            return new ParentAccountResource
            {
                AccountNumber = entity.AccountNumber,
                Name = entity.Name,
                IsoCurrencyCode = entity.Currency?.IsoCode
            };
        }
    }
}
