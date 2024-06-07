namespace AmazonPrimeClone.Domain.Entities;
public class Country : BaseEntity<string>
{
    public string? CountryName { get; set; }
    public string? CountryCode { get; set; }
    public RegionStatus Status { get; set; }
    public ICollection<City> Cities { get; set; } = [];
    public ICollection<UserProfile> Users { get; set; } = [];
}
