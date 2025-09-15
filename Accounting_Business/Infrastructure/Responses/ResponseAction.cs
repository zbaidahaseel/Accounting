using Accounting_Business.Infrastructure.Enums;
using Accounting_Business.Languages;

namespace Accounting_Business.Infrastructure.Responses
{
    public static class ResponseAction
    {
        public static Response ToSuccessResponse() => new()
        {
            Code = (int)CodeResponseEnums.Success,
            Message = Resource.SuccessfulOperation,
            Data = new { },
            Status = true
        };
        public static Response ToSuccessResponseWithModel<T>(this T model) => new()
        {
            Code = (int)CodeResponseEnums.Success,
            Message = Resource.SuccessfulOperation,
            Data = model,
            Status = true
        };
    }
}
