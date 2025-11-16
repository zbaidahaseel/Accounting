using Accounting_Business.Managers;
using Accounting_Business.Persistence.Models;
using Microsoft.AspNetCore.Mvc;

namespace Accounting_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherManager _voucherManager;

        public VoucherController(IVoucherManager voucherManager)
        {
            _voucherManager = voucherManager;
        }
        public async Task<IActionResult> AddVoucher(VoucherModel voucherModel)
        {
            var result = await _voucherManager.AddVoucher(voucherModel);
            return Ok(result);
        }

        public async Task<IActionResult> UpdateVoucher(VoucherModel voucherModel)
        {
            var result = await _voucherManager.UpdateVoucher(voucherModel);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoucher(int id)
        {
            var result = await _voucherManager.DeleteVoucher(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVoucherById(int id)
        {
            var result = await _voucherManager.GetVoucherById(id);
            return Ok(result);
        }

        public async Task<IActionResult> GetAllVouchers()
        {
            var result = await _voucherManager.GetAllVouchers();
            return Ok(result);
        }
        public async Task<IActionResult> AddJournalVoucher(JournalVoucherModel voucherModel)
        {
            var result = await _voucherManager.AddJournalVoucher(voucherModel);
            return Ok(result);
        }

        public async Task<IActionResult> UpdateJournalVoucher(JournalVoucherModel voucherModel)
        {
            var result = await _voucherManager.UpdateJournalVoucher(voucherModel);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJournalVoucher(int id)
        {
            var result = await _voucherManager.DeleteJournalVoucher(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJournalVoucherById(int id)
        {
            var result = await _voucherManager.GetJournalVoucherById(id);
            return Ok(result);
        }

        public async Task<IActionResult> GetAllJournalVouchers()
        {
            var result = await _voucherManager.GetAllJournalVouchers();
            return Ok(result);
        }
    }
}
