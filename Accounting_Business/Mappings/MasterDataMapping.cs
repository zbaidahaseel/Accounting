using Accounting_Business.Persistence.Entities;
using Accounting_Business.Persistence.Models;
using Accounting_Business.Persistence.Resources;
using AutoMapper;

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

        public static CityResource ToResource(this City model)
        {
            if (model == null) return null;
            return new CityResource
            {
                Id = model.Id,
                Name = model.Name,
                IsActive = model.IsActive
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
        public static CostCenterResource ToResource(this CostCenter model)
        {
            if (model == null) return null;
            return new CostCenterResource
            {
                Id = model.Id,
                Name = model.Name,
                IsActive = model.IsActive
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

        public static AgentResource ToResource(this Agent model)
        {
            if (model == null) return null;
            return new AgentResource
            {
                Id = model.Id,
                Name = model.Name,
                IsActive = model.IsActive
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

        public static ReceivablesPayablesClassificationResource ToResource(this ReceivablesPayablesClassification model)
        {
            if (model == null) return null;
            return new ReceivablesPayablesClassificationResource
            {
                Id = model.Id,
                Name = model.Name,
                IsActive = model.IsActive
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
        public static ChartOfAccountResource ToChartOfAccountResource(this Account entity, IMapper mapper)
        {
            if (entity == null) return null;
            var resource = mapper.Map<Account, ChartOfAccountResource>(entity);
            resource.AccountName = entity.Name;
            resource.AccountClassificationName = entity.AccountClassification?.Name;
            resource.ParentAccountName = entity.ParentAccount?.Name;
            return resource;
        }

        public static Currency ToEntity(this CurrencyModel model, IMapper mapper)
        {
            if (model == null) return null;
            return mapper.Map<CurrencyModel, Currency>(model);         
        }

        public static CurrencyResource ToResource(this Currency entity, IMapper mapper)
        {
            if (entity == null) return null;
            return mapper.Map<Currency, CurrencyResource>(entity);
        }

        public static ExchangeCurrency ToEntity(this ExchangeCurrencyModel model, IMapper mapper)
        {
            if (model == null) return null;
            return mapper.Map<ExchangeCurrencyModel, ExchangeCurrency>(model);
        }

        public static ExchangeCurrencyResource ToResource(this ExchangeCurrency entity, IMapper mapper)
        {
            if (entity == null) return null;
            return mapper.Map<ExchangeCurrency, ExchangeCurrencyResource>(entity);
        }

    }
}
