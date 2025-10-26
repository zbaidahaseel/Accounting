namespace Accounting_Business.Persistence.Models
{
    public class ProfileModel
    {
        public string ProfileNumber { get; set; }
        public string? Name { get; set; }
        public string? EnglishName { get; set; }
        public string? IdentificationNumber { get; set; }
        public int? ClassificationId { get; set; }
        public int? CurrencyId { get; set; }
        public string? Address { get; set; }
        public int? CityId { get; set; }
        public int? PhoneNumber { get; set; }
        public int? MobileNumber { get; set; }
        public int? Fax { get; set; }
        public int? PriceCategory { get; set; }
        public double? Discount { get; set; }
        public double? CreditLimit { get; set; }
        public int? AgentId { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public List<AdditionalInformationModel> AdditionalInformations { get; set; }
        public List<SubAccountModel> SubAccounts { get; set; }

    }

    public class AdditionalInformationModel
    {
        public string? Name { get; set; }
    }

    public class SubAccountModel
    {
        public string? Name { get; set; }
    }
}
