using AmazonPrimeClone.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AmazonPrimeClone.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public UserProfile UserProfile { get; set; } = null!;
}
