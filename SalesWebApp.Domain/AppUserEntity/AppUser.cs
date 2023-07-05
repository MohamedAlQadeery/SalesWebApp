using Microsoft.AspNetCore.Identity;
using SalesWebApp.Domain.AppUserEntity.Enums;
using SalesWebApp.Domain.Common.ValueObjects;

namespace SalesWebApp.Domain.AppUserEntity;

public class AppUser : IdentityUser
{
    public AppUserRole AppUserRole { get; set; } = AppUserRole.Guest;
    public Address Address { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;


    public DateTime CreatedDateTime { get; private set; } = DateTime.Now;
    public DateTime? UpdatedDateTime { get; set; }
    public bool IsActive { get; private set; } = true;


    public void ToggleStatus()
    {
        IsActive = !IsActive;
    }

}