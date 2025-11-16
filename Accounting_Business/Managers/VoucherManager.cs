using Accounting_Business.Infrastructure.Responses;
using Accounting_Business.Mappings;
using Accounting_Business.Persistence.Entities;
using Accounting_Business.Persistence.Models;
using Accounting_Business.Services;
using AutoMapper;

namespace Accounting_Business.Managers
{
    public interface IVoucherManager
    {
        Task<Response> AddVoucher(VoucherModel voucherModel);
        Task<Response> UpdateVoucher(VoucherModel voucherModel);
        Task<Response> DeleteVoucher(int id);
        Task<Response> GetVoucherById(int id);
        Task<Response> GetAllVouchers();
        Task<Response> AddJournalVoucher(JournalVoucherModel voucherModel);
        Task<Response> UpdateJournalVoucher(JournalVoucherModel voucherModel);
        Task<Response> DeleteJournalVoucher(int id);
        Task<Response> GetJournalVoucherById(int id);
        Task<Response> GetAllJournalVouchers();
    }
    public class VoucherManager : IVoucherManager
    {
        private readonly IVoucherService _voucherService;
        private readonly IVoucherCheckService _voucherCheckService;
        private readonly IJournalVoucherService _journalVoucherService;
        private readonly IJournalVoucherCheckService _journalVoucherCheckService;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public VoucherManager(IVoucherService voucherService,
            IVoucherCheckService voucherCheckService,
            IJournalVoucherService journalVoucherService,
            IJournalVoucherCheckService journalVoucherCheckService,
            IMapper mapper,
            AppDbContext context)
        {
            _voucherService = voucherService;
            _voucherCheckService = voucherCheckService;
            _journalVoucherService = journalVoucherService;
            _journalVoucherCheckService = journalVoucherCheckService;
            _mapper = mapper;
            _context = context;
        }

        public async Task<Response> AddVoucher(VoucherModel voucherModel)
        {
            var voucher = voucherModel.ToEntity(_mapper);

            var voucherChecks = voucherModel.VoucherChecks.Select(e => e.ToEntity(_mapper)).ToList();

            voucher.VoucherChecks = voucherChecks;

            _voucherService.Add(voucher);

            await _context.SaveChangesAsync();
            
            return voucher.Id.ToSuccessResponseWithModel();
        }


        public async Task<Response> UpdateVoucher(VoucherModel voucherModel)
        {

            var voucher = await _voucherService.GetById(voucherModel.Id.Value);

            voucher = voucherModel.ToEntity(voucher, _mapper);

            _voucherService.Update(voucher);

            var existingVoucherChecks = await _voucherCheckService.GetByVoucherId(voucher.Id);

            _voucherCheckService.Delete(existingVoucherChecks);

            var voucherChecks = voucherModel.VoucherChecks.Select(e => e.ToEntity(_mapper)).ToList();

            voucher.VoucherChecks = voucherChecks;

            _voucherCheckService.Add(voucherChecks);

            await _context.SaveChangesAsync();

            return ResponseAction.ToSuccessResponse();
        }

        public async Task<Response> DeleteVoucher(int id)
        {

            var voucher = await _voucherService.GetById(id);

            var existingVoucherChecks = await _voucherCheckService.GetByVoucherId(voucher.Id);

            _voucherCheckService.Delete(existingVoucherChecks);

            _voucherService.Delete(voucher);

            await _context.SaveChangesAsync();

            return ResponseAction.ToSuccessResponse();
        }

        public async Task<Response> GetVoucherById(int id)
        {
            var voucher = await _voucherService.GetById(id);
           
            var voucherResource = voucher.ToResource(_mapper);

            var voucherChecks = await _voucherCheckService.GetByVoucherId(voucher.Id);

            voucherResource.VoucherChecks = voucherChecks.Select(vc => vc.ToResource(_mapper)).ToList();

            return voucherResource.ToSuccessResponseWithModel();
        }

        public async Task<Response> GetAllVouchers()
        {
            var vouchers = await _voucherService.GetAll();

            var voucherResources = vouchers.Select(v => v.ToResource(_mapper)).ToList();

            return voucherResources.ToSuccessResponseWithModel();
        }

        public async Task<Response> AddJournalVoucher(JournalVoucherModel voucherModel)
        {
            var voucher = voucherModel.ToEntity(_mapper);

            var voucherChecks = voucherModel.JournalVoucherChecks.Select(e => e.ToEntity(_mapper)).ToList();

            voucher.JournalVoucherChecks = voucherChecks;

            _journalVoucherService.Add(voucher);

            await _context.SaveChangesAsync();

            return voucher.Id.ToSuccessResponseWithModel();
        }


        public async Task<Response> UpdateJournalVoucher(JournalVoucherModel voucherModel)
        {

            var voucher = await _journalVoucherService.GetById(voucherModel.Id.Value);

            voucher = voucherModel.ToEntity(voucher, _mapper);

            _journalVoucherService.Update(voucher);

            var existingVoucherChecks = await _voucherCheckService.GetByVoucherId(voucher.Id);

            _voucherCheckService.Delete(existingVoucherChecks);

            var voucherChecks = voucherModel.JournalVoucherChecks.Select(e => e.ToEntity(_mapper)).ToList();

            voucher.JournalVoucherChecks = voucherChecks;

            _journalVoucherCheckService.Add(voucherChecks);

            await _context.SaveChangesAsync();

            return ResponseAction.ToSuccessResponse();
        }

        public async Task<Response> DeleteJournalVoucher(int id)
        {

            var voucher = await _journalVoucherService.GetById(id);

            var existingVoucherChecks = await _journalVoucherCheckService.GetByVoucherId(voucher.Id);

            _journalVoucherCheckService.Delete(existingVoucherChecks);

            _journalVoucherService.Delete(voucher);

            await _context.SaveChangesAsync();

            return ResponseAction.ToSuccessResponse();
        }

        public async Task<Response> GetJournalVoucherById(int id)
        {
            var voucher = await _journalVoucherService.GetById(id);

            var voucherResource = voucher.ToResource(_mapper);

            var voucherChecks = await _journalVoucherCheckService.GetByVoucherId(voucher.Id);

            voucherResource.JournalVoucherChecks = voucherChecks.Select(vc => vc.ToResource(_mapper)).ToList();

            return voucherResource.ToSuccessResponseWithModel();
        }

        public async Task<Response> GetAllJournalVouchers()
        {
            var vouchers = await _journalVoucherService.GetAll();

            var voucherResources = vouchers.Select(v => v.ToResource(_mapper)).ToList();

            return voucherResources.ToSuccessResponseWithModel();
        }
    }
}
