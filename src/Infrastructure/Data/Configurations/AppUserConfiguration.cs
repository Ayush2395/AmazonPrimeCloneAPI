using AmazonPrimeClone.Domain.Entities;
using AmazonPrimeClone.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonPrimeClone.Infrastructure.Data.Configurations;
public class AppUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasOne(x => x.UserProfile)
            .WithOne()
            .HasForeignKey<UserProfile>(fk => fk.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
