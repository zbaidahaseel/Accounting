using Accounting_Business.Infrastructure.Exceptions;
using Accounting_Business.Infrastructure.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;


namespace Accounting_Business.Infrastructure.Handlers
{
    public class GlobalExceptionHandler : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var result = new ErrorResponse
            {
                TraceId = context.HttpContext.TraceIdentifier
            };
            var statusCode = StatusCodes.Status500InternalServerError;

            switch (context.Exception)
            {
                case AccountingException accountingException:
                    statusCode = accountingException.GetStatusCode();
                    if (accountingException.GetErrors() is object errors) result.ErrorDetails = errors;
                    break;
                case DbUpdateConcurrencyException _:
                    statusCode = StatusCodes.Status409Conflict;
                    result.ErrorDetails = new Dictionary<string, List<string>>
                    {
                        {
                            "timestamp",
                            new List<string> {"Timestamp value is not valid."}
                        }
                    };
                    break;
            }

            result.Message = context.Exception.Message;
            result.StackTrace = context.Exception.ToString();

            context.Result = new ObjectResult(result)
            {
                StatusCode = statusCode,
                DeclaredType = typeof(ErrorResponse)
            };
        }
    }
}
