using AmazonPrimeClone.Domain.Constants;
using AmazonPrimeClone.Domain.Entities;
using AmazonPrimeClone.Domain.Enums;
using AmazonPrimeClone.Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AmazonPrimeClone.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new IdentityRole(Roles.Administrator);

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new ApplicationUser { UserName = "ayush@demo.com", Email = "ayush@demo.com" };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Test@123");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await _userManager.AddToRolesAsync(administrator, [administratorRole.Name]);
            }
            await _context.UserProfiles.AddAsync(new()
            {
                Id = administrator.Id,
                FirstName = "Ayush",
                DateOfBirth = DateTime.UtcNow
            });
            await _context.SaveChangesAsync();
        }

        // Default data
        if (!_context.SubscriptionPlans.Any())
        {
            List<SubscriptionPlan> plans = [
                new SubscriptionPlan{
                    Title="Base plan",
                    PlanType=SubscriptionType.BasePlan,
                    Price=149.98M,
                    Description="Basic plan, access for 720p",
                },
                new SubscriptionPlan{
                    Title="Blaze plan",
                    PlanType=SubscriptionType.BlazePlan,
                    Price=149.98M,
                    Description="Blaze plan, access for 1080p",
                },
                new SubscriptionPlan{
                    Title="Premium plan",
                    PlanType=SubscriptionType.PremiumPlan,
                    Price=149.98M,
                    Description="Premium plan, access for 4k",
                }];
            await _context.SubscriptionPlans.AddRangeAsync(plans);
            await _context.SaveChangesAsync();
        }
        if (!_context.Countries.Any())
        {
            List<Country> countries = [
                new Country{
                    CountryName="India",
                    CountryCode="91",
                    Status= RegionStatus.Active
                },
                new Country{
                    CountryName="USA",
                    CountryCode="1",
                    Status= RegionStatus.Active
                },
                new Country{
                    CountryName="Pakistan",
                    CountryCode="92",
                    Status= RegionStatus.Inactive
                }];
            await _context.Countries.AddRangeAsync(countries);
            await _context.SaveChangesAsync();
        }
    }
}
