namespace Accounting_Business.Persistence.Models
{
    public class EmployeeModel
    {
        public string? EmployeeCode { get; set; }

        public string? Name { get; set; }

        public int ClassificationId { get; set; }

        public string? IdentificationNumber { get; set; }

        public string? Address { get; set; }

        public int? CityId { get; set; }

        public string? FirstPhoneNumber { get; set; }

        public string? SecondPhoneNumber { get; set; }

        public DateOnly? BirthDate { get; set; }

        public DateOnly? HiringDate { get; set; }

        public DateOnly? EndOfServiceDate { get; set; }

        public int? MaritalStatusId { get; set; }

        public int? GenderId { get; set; }

        public double? CreditLimit { get; set; }

        public int? NumberOfChildren { get; set; }

        public string? EmployeeImagePath { get; set; }
    }
}
