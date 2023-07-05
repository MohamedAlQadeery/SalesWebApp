
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SalesWebApp.Domain.AppUserEntity;
using SalesWebApp.Domain.AppUserEntity.Enums;
using SalesWebApp.Domain.Common.ValueObjects;

namespace SalesWebApp.Infrastructure.Persistence;

public class AppDbContextInitialiser
{
    private readonly AppDbContext _context;
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AppDbContextInitialiser(AppDbContext context, UserManager<AppUser> userManager,
     RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {

        if (_context.Database.IsSqlServer())
        {
            await _context.Database.MigrateAsync();
        }

    }

    public async Task SeedAsync()
    {

        //check if already seeded
        if (_context.Users.Any())
        {
            return;
        }


        await TrySeedAsync();


    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new IdentityRole("admin");



        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
            await _roleManager.CreateAsync(new IdentityRole("salesman"));
            await _roleManager.CreateAsync(new IdentityRole("deilveryman"));
            await _roleManager.CreateAsync(new IdentityRole("guest"));
        }

        // Default users
        var administrator = new AppUser
        {
            UserName = "admin@admin.com",
            Email = "admin@admin.com",
            EmailConfirmed = true
        ,
            AppUserRole = AppUserRole.Admin,
            FirstName = "Admin",
            LastName = "Admin",
            Address = Address.Create("AdminStreet", "AdminCity", "AdminCountry", "AdminZipcode")
        };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Admin123@");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                var result = await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });

            }
        }



        await _context.SaveChangesAsync();

    }
}
