namespace Accounting_Business.Persistence.Models
{
    public class EmployeeFilterModel
    {
        public string? EmployeeCode { get; set; }
        public string? Name { get; set; }
        public string? IdenificationNumber { get; set; }
        public string? Address { get; set; }
        public string? FirstPhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HiringDate { get; set; }
    }
}
