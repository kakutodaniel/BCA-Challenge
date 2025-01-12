namespace Auction.Application.Error
{
    public class ErrorMessage
    {
        public static string NotNull = "{0} - Can not be null";

        public static string NotEmpty = "{0} - Can not be empty";

        public static string MinimumLength = "{0} - Minimum length allowed is {1}";

        public static string MaximumLength = "{0} - Maximum length allowed is {1}";

        public static string InclusiveBetween = "{0} - Value must be between {1} and {2}";

        public static string GreaterThanOrEqualTo = "{0} - Value must be greater than or equal to {1}";
    }
}
