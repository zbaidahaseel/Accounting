using Accounting_Business.Persistence.Entities;
using Accounting_Business.Persistence.Models;
using Accounting_Business.Persistence.Resources;
using AutoMapper;

namespace Accounting_Business.Mappings
{
    public static class VoucherMapping
    {
        public static Voucher ToEntity(this VoucherModel model, IMapper mapper)
        {
            return mapper.Map<Voucher>(model);
        }

        public static Voucher ToEntity(this VoucherModel model, Voucher voucher, IMapper mapper)
        {
            return mapper.Map(model, voucher);
        }
        public static VoucherResource ToResource(this Voucher model, IMapper mapper)
        {
            return mapper.Map<VoucherResource>(model);
        }

        public static VoucherCheck ToEntity(this VoucherCheckModel model, IMapper mapper)
        {
            return mapper.Map<VoucherCheck>(model);
        }
        public static VoucherCheckResource ToResource(this VoucherCheck model, IMapper mapper)
        {
            return mapper.Map<VoucherCheckResource>(model);
        }

        public static JournalVoucher ToEntity(this JournalVoucherModel model, IMapper mapper)
        {
            return mapper.Map<JournalVoucher>(model);
        }

        public static JournalVoucher ToEntity(this JournalVoucherModel model, JournalVoucher voucher, IMapper mapper)
        {
            return mapper.Map(model, voucher);
        }
        public static JournalVoucherResource ToResource(this JournalVoucher model, IMapper mapper)
        {
            return mapper.Map<JournalVoucherResource>(model);
        }

        public static JournalVoucherCheck ToEntity(this JournalVoucherCheckModel model, IMapper mapper)
        {
            return mapper.Map<JournalVoucherCheck>(model);
        }
        public static JournalVoucherCheckResource ToResource(this JournalVoucherCheck model, IMapper mapper)
        {
            return mapper.Map<JournalVoucherCheckResource>(model);
        }
    }
}
