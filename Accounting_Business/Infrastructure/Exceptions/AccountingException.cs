namespace Accounting_Business.Infrastructure.Exceptions
{
    public interface AccountingException
    {
        int GetStatusCode();

        object? GetErrors();        
    }
}
