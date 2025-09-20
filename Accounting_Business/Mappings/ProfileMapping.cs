using Accounting_Business.Persistence.Entities;
using Accounting_Business.Persistence.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_Business.Mappings
{
    public static class ProfileMapping
    {
        public static Persistence.Entities.Profile ToEntity(this ProfileModel model, IMapper mapper)
        {
            if (model == null) return null;

            return mapper.Map<ProfileModel, Persistence.Entities.Profile>(model);
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
    }
}
