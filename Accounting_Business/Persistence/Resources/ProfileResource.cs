namespace Accounting_Business.Persistence.Resources
{
    public class ProfileResource
    {
        public int Id { get; set; }

        public string ProfileCode { get; set; }

        public string Name { get; set; }

        public string EnglishName { get; set; }

        public string IdentificationNumber { get; set; }

        public int ClassificationId { get; set; }

        public string? ClassificationName { get; set; }

        public int? CurrencyId { get; set; }

        public string? CurrencyName { get; set; }

        public string Address { get; set; }

        public int? CityId { get; set; }

        public string? CityName { get; set; }

        public string PhoneNumber { get; set; }

        public string MobileNumber { get; set; }

        public string Fax { get; set; }

        public int? PriceCategory { get; set; }

        public decimal? Discount { get; set; }

        public decimal? CreditLimit { get; set; }

        public int? AgentId { get; set; }

        public string? AgentName { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public bool? IsActive { get; set; }

        public int? ProfileTypeId { get; set; }
    }
    public class AdditionalInformationResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProfileSubAccountResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
