using Ardalis.SmartEnum;

namespace SalesWebApp.Domain.AppUserEntity.Enums
{

    public sealed class AppUserRole : SmartEnum<AppUserRole>
    {
        public AppUserRole(string name, int value) : base(name, value)
        {
        }
        public static readonly AppUserRole Admin = new(nameof(Admin), 1);
        public static readonly AppUserRole Salesman = new(nameof(Salesman), 2);
        public static readonly AppUserRole Deliveryman = new(nameof(Deliveryman), 3);
        public static readonly AppUserRole Guest = new(nameof(Guest), 4);
    }
}