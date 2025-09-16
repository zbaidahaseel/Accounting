using Accounting_Business.Infrastructure.Responses;
using Accounting_Business.Mappings;
using Accounting_Business.Persistence.Entities;
using Accounting_Business.Persistence.Models;
using Accounting_Business.Services;
using AutoMapper;

namespace Accounting_Business.Managers
{
    public interface IMasterDataManager
    {
        Task<Response> GetAllCities();
        Task<Response> AddCity(CityModel cityModel);
        Task<Response> DeleteCity(int id);
        Task<Response> GetAllCostCenters();
        Task<Response> AddCostCenter(CostCenterModel costCenterModel);
        Task<Response> DeleteCostCenter(int id);
        Task<Response> GetAllAgents();
        Task<Response> AddAgent(AgentModel agentModel);
        Task<Response> DeleteAgent(int id);
        Task<Response> GetAllReceivablesPayablesClassifications();
        Task<Response> AddReceivablesPayablesClassification(ReceivablesPayablesClassificationModel ReceivablesPayablesClassificationModel);
        Task<Response> DeleteReceivablesPayablesClassification(int id);
        Task<Response> AddAccount(AccountModel account);
        Task<Response> UpdateAccount(AccountModel account);
        Task<Response> GetAccountByNumber(string accountNumber);
        Task<Response> GetAllAccounts();
    }
    public class MasterDataManager : IMasterDataManager
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICityService _cityService;
        private readonly ICostCenterService _costCenterService;
        private readonly IAgentService _agentService;
        private readonly IReceivablesPayablesClassificationService _receivablesPayablesClassificationService;
        private readonly IAccountService _accountService;

        public MasterDataManager(AppDbContext context,
            IMapper mapper,
            ICityService cityService,
            ICostCenterService costCenterService,
            IAgentService agentService,
            IReceivablesPayablesClassificationService receivablesPayablesClassificationService,
            IAccountService accountService)
        {
            _context = context;
            _mapper = mapper;
            _cityService = cityService;
            _costCenterService = costCenterService;
            _agentService = agentService;
            _receivablesPayablesClassificationService = receivablesPayablesClassificationService;
            _accountService = accountService;
        }

        public async Task<Response> GetAllCities()
        {
            var cities = await _cityService.GetAllCities();
            return cities.ToSuccessResponseWithModel();
        }

        public async Task<Response> AddCity(CityModel cityModel)
        {
            var city = cityModel.ToEntity();
           
            _cityService.Add(city);
            
            await _context.SaveChangesAsync();

            return city.Id.ToSuccessResponseWithModel();
        }

        public async Task<Response> DeleteCity(int id)
        {
            var city = await _cityService.Get(id);

            _cityService.Delete(city);

            await _context.SaveChangesAsync();

            return ResponseAction.ToSuccessResponse();
        }

        public async Task<Response> GetAllCostCenters()
        {
            var cities = await _costCenterService.GetAll();
            return cities.ToSuccessResponseWithModel();
        }

        public async Task<Response> AddCostCenter(CostCenterModel costCenterModel)
        {
            var costCenter = costCenterModel.ToEntity();

            _costCenterService.Add(costCenter);

            await _context.SaveChangesAsync();

            return costCenter.Id.ToSuccessResponseWithModel();
        }

        public async Task<Response> DeleteCostCenter(int id)
        {
            var costCenter = await _costCenterService.Get(id);

            _costCenterService.Delete(costCenter);

            await _context.SaveChangesAsync();

            return ResponseAction.ToSuccessResponse();
        }

        public async Task<Response> GetAllAgents()
        {
            var cities = await _agentService.GetAll();
            return cities.ToSuccessResponseWithModel();
        }

        public async Task<Response> AddAgent(AgentModel agentModel)
        {
            var agent = agentModel.ToEntity();

            _agentService.Add(agent);

            await _context.SaveChangesAsync();

            return agent.Id.ToSuccessResponseWithModel();
        }

        public async Task<Response> DeleteAgent(int id)
        {
            var agent = await _agentService.Get(id);

            _agentService.Delete(agent);

            await _context.SaveChangesAsync();

            return ResponseAction.ToSuccessResponse();
        }

        public async Task<Response> GetAllReceivablesPayablesClassifications()
        {
            var cities = await _receivablesPayablesClassificationService.GetAll();
            return cities.ToSuccessResponseWithModel();
        }

        public async Task<Response> AddReceivablesPayablesClassification(ReceivablesPayablesClassificationModel ReceivablesPayablesClassificationModel)
        {
            var receivablesPayablesClassification = ReceivablesPayablesClassificationModel.ToEntity();

            _receivablesPayablesClassificationService.Add(receivablesPayablesClassification);

            await _context.SaveChangesAsync();

            return receivablesPayablesClassification.Id.ToSuccessResponseWithModel();
        }

        public async Task<Response> DeleteReceivablesPayablesClassification(int id)
        {
            var receivablesPayablesClassificationEntity = await _receivablesPayablesClassificationService.Get(id);

            _receivablesPayablesClassificationService.Delete(receivablesPayablesClassificationEntity);

            await _context.SaveChangesAsync();

            return ResponseAction.ToSuccessResponse();
        }

        public async Task<Response> AddAccount(AccountModel account)
        {
            var entity = account.ToEntity(_mapper);
          
            _accountService.Add(entity);
            
            await _context.SaveChangesAsync();
            
            return entity.AccountNumber.ToSuccessResponseWithModel();
        }
        public async Task<Response> UpdateAccount(AccountModel account)
        {
            var entity = await _accountService.Get(account.AccountNumber);
            //if (entity == null)
            //{
            //    return ResponseAction.ToNotFoundResponse($"Account with id {account.Id} not found.");
            //}
            entity = account.ToEntity(_mapper);

            _accountService.Update(entity);

            await _context.SaveChangesAsync();

            return ResponseAction.ToSuccessResponse();
        }

        public async Task<Response> GetAccountByNumber(string accountNumber)
        {
            var account = await _accountService.Get(accountNumber);
            //if (account == null)
            //{
            //    return ResponseAction.ToNotFoundResponse($"Account with number {accountNumber} not found.");
            //}
            var resource = account.ToResource(_mapper);

            return resource.ToSuccessResponseWithModel();
        }
        public async Task<Response> GetAllAccounts()
        {
            var accounts = await _accountService.GetAll();
           
            var resource = accounts.Select(item => item.ToParentResources()).ToList();
            
            return resource.ToSuccessResponseWithModel();
        }
    }

}
