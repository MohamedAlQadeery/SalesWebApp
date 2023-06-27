using ErrorOr;
namespace SalesApp.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials =>
            Error.Validation(code: "InvalidCredentials", description: "Invalid credentials");
    }
}