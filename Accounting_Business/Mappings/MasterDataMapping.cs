using Accounting_Business.Persistence.Entities;
using Accounting_Business.Persistence.Models;

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
    }
}
