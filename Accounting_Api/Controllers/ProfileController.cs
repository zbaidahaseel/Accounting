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
            var result = await _profileManager.AddProfile(profileModel);
            return Ok(result);
        }

        public async Task<IActionResult> DeleteProfile(string profileCode)
        {
            var result = await _profileManager.DeleteProfile(profileCode);
            return Ok(result);
        }
    }
}
