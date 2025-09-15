namespace Accounting_Business.Infrastructure.Responses
{
    public class Response
    {
        public int Code { get; set; }

        //
        // Summary:
        //     الرسالة
        public string Message { get; set; }

        //
        // Summary:
        //     الحالة
        public bool Status { get; set; }

        //
        // Summary:
        //     البيانات الاضافية
        public object Data { get; set; }
    }
}
