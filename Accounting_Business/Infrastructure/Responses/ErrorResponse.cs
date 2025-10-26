namespace Accounting_Business.Infrastructure.Responses
{
    public class ErrorResponse
    {
        public string TraceId { get; set; }
        public string Message { get; set; }
        public object ErrorDetails { get; set; }

        public string StackTrace { get; set; }
    }

    public class ErrorResponse<T> : ErrorResponse
    {
        public new T ErrorDetails { get; set; }
    }
}
