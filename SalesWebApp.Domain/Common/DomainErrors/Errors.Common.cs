using ErrorOr;

namespace SalesApp.Domain.Common.DomainErrors;
public static partial class Errors
{
    public static class Common
    {

        public static Error InvalidId =>
         Error.Validation(code: "InvalidId", description: "Id is invalid");

        public static Error InvalidName =>
            Error.Validation(code: "InvalidName", description: "Name is invalid");
    }



}