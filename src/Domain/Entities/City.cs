namespace AmazonPrimeClone.Domain.Entities;
public class City : BaseEntity<string>
{
    public string? CountryId { get; set; }
    public string? CityName { get; set; }
    public RegionStatus Status { get; set; }
    public Country Country { get; set; } = null!;
    public ICollection<UserProfile> Users { get; set; } = [];
}
