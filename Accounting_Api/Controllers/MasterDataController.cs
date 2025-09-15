using Accounting_Business.Managers;
using Accounting_Business.Persistence.Models;
using Microsoft.AspNetCore.Mvc;

namespace Accounting_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MasterDataController : ControllerBase
    {
        private readonly IMasterDataManager _masterDataManager;

        public MasterDataController(IMasterDataManager masterDataManager)
        {
            _masterDataManager = masterDataManager;
        }

        public async Task<IActionResult> Cities()
        {
            var cities = await _masterDataManager.GetAllCities();
            return Ok(cities);
        }

        public async Task<IActionResult> AddCity(CityModel cityModel)
        {
            var cityId = await _masterDataManager.AddCity(cityModel);
            return Ok(cityId);
        }

        public async Task<IActionResult> DeleteCity(int id)
        {
            var cityId = await _masterDataManager.DeleteCity(id);
            return Ok(cityId);
        }

        public async Task<IActionResult> CostCenters()
        {
            var result = await _masterDataManager.GetAllCostCenters();
            return Ok(result);
        }

        public async Task<IActionResult> AddCostCenter(CostCenterModel costCenterModel)
        {
            var result = await _masterDataManager.AddCostCenter(costCenterModel);
            return Ok(result);
        }

        public async Task<IActionResult> DeleteCostCenter(int id)
        {
            var result = await _masterDataManager.DeleteCostCenter(id);
            return Ok(result);
        }

        public async Task<IActionResult> Agents()
        {
            var result = await _masterDataManager.GetAllAgents();
            return Ok(result);
        }

        public async Task<IActionResult> AddAgent(AgentModel agentModel)
        {
            var result = await _masterDataManager.AddAgent(agentModel);
            return Ok(result);
        }

        public async Task<IActionResult> DeleteAgent(int id)
        {
            var result = await _masterDataManager.DeleteAgent(id);
            return Ok(result);
        }

        public async Task<IActionResult> ReceivablesPayablesClassifications()
        {
            var result = await _masterDataManager.GetAllReceivablesPayablesClassifications();
            return Ok(result);
        }

        public async Task<IActionResult> AddReceivablesPayablesClassification(ReceivablesPayablesClassificationModel receivablesPayablesClassificationModel)
        {
            var result = await _masterDataManager.AddReceivablesPayablesClassification(receivablesPayablesClassificationModel);
            return Ok(result);
        }

        public async Task<IActionResult> DeleteReceivablesPayablesClassification(int id)
        {
            var result = await _masterDataManager.DeleteReceivablesPayablesClassification(id);
            return Ok(result);
        }
    }
}
