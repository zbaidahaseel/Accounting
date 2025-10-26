using Accounting_Business.Managers;
using Accounting_Business.Persistence.Models;
using Microsoft.AspNetCore.Mvc;

namespace Accounting_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileManager _profileManager;
        public ProfileController(IProfileManager profileManager)
        {
            _profileManager = profileManager;
        }

        public async Task<IActionResult> AddProfile(ProfileModel profileModel)
        {
            var result = await _profileManager.AddProfile(profileModel);
            return Ok(result);
        }

        public async Task<IActionResult> UpdateProfile(ProfileModel profileModel)
        {
            var result = await _profileManager.UpdateProfile(profileModel);
            return Ok(result);
        }

        public async Task<IActionResult> DeleteProfile(string profileCode)
        {
            var result = await _profileManager.DeleteProfile(profileCode);
            return Ok(result);
        }

        public async Task<IActionResult> GetProfile(string profileCode)
        {
            var result = await _profileManager.GetProfile(profileCode);
            return Ok(result);
        }

        public async Task<IActionResult> AddEmployee(EmployeeModel employeeModel)
        {
            var result = await _profileManager.AddEmployee(employeeModel);
            return Ok(result);
        }

        public async Task<IActionResult> UpdateEmployee(EmployeeModel employeeModel)
        {
            var result = await _profileManager.UpdateEmployee(employeeModel);
            return Ok(result);
        }

        public async Task<IActionResult> DeleteEmployee(string employeeCode)
        {
            var result = await _profileManager.DeleteEmployee(employeeCode);
            return Ok(result);
        }

        public async Task<IActionResult> GetEmployee(string employeeCode)
        {
            var result = await _profileManager.GetEmployee(employeeCode);
            return Ok(result);
        }

        public async Task<IActionResult> GetEmployeesByFilters([FromQuery] EmployeeFilterModel employeeFilter)
        {
            var result = await _profileManager.GetEmployeesByFilters(employeeFilter);
            return Ok(result);
        }
    }
}
