using Utmbuilder.Core.ValueObjects.Exceptions;

namespace Utmbuilder.Core.ValueObjects
{
    public class Url : ValueObject
    {

        /// <summary>
        /// Create a new URL
        /// </summary>
        /// <param name="address">Address of URL</param>
        public Url(string address) 
        {
            Address = address;
            InvalidUrlException.ThrowIfINvalid(address);
        }

        /// <summary>
        /// Address of URL (Website link)
        /// </summary>
        public string Address { get; }
    }
}
