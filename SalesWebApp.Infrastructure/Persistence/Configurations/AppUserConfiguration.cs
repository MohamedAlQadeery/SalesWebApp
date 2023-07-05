using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesWebApp.Domain.AppUserEntity;
using SalesWebApp.Domain.AppUserEntity.Enums;

namespace SalesWebApp.Infrastructure.Persistence.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.OwnsOne(au => au.Address);

            builder.Property(au => au.AppUserRole)
                    .HasConversion(role => role.Value, roleValue => AppUserRole.FromValue(roleValue));
        }
    }
}