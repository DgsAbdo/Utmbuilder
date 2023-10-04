using System.Text.RegularExpressions;

namespace Utmbuilder.Core.ValueObjects.Exceptions
{
    public partial class InvalidUrlException : Exception
    {
        private const string DefaultErrorMessage = "Invalid URL";

        public InvalidUrlException(string message = DefaultErrorMessage) : base(message)
        {
            
        }

        public static void ThrowIfINvalid(string address, string message = DefaultErrorMessage)
        {
            if(string.IsNullOrEmpty(address))
                throw new InvalidUrlException(message);

            if (!UrlRegex().IsMatch(address))
                throw new InvalidUrlException();

        }

        [GeneratedRegex("/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/")]
        private static partial Regex UrlRegex();
    }
}
