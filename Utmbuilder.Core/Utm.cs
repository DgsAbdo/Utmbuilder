using Utmbuilder.Core.Extensions;
using Utmbuilder.Core.ValueObjects;
using Utmbuilder.Core.ValueObjects.Exceptions;

namespace Utmbuilder.Core
{
    public class Utm
    {
        public Utm(Url url, Campaing campaing) 
        { 
            Url = url;
            Campaing = campaing;
        }

        /// <summary>
        /// URL (Website Link)
        /// </summary>
        public Url Url { get; }

        /// <summary>
        /// Campaign Details
        /// </summary>
        public Campaing Campaing { get; init; }

        public static implicit operator string(Utm utm)
            => utm.ToString();

        public static implicit operator Utm(string link)
        {
            if (string.IsNullOrEmpty(link))
                throw new InvalidUrlException();

            var url = new Url(link);
            var segments = url.Address.Split("?");
            
            if (segments.Length == 1)
                throw new InvalidUrlException("No segments were provided");

            var pars = segments[1].Split("&");
            var source = pars.Where(x => x.StartsWith("utm_source")).FirstOrDefault("").Split("=")[1];
            var medium = pars.Where(x => x.StartsWith("utm_medium")).FirstOrDefault("").Split("=")[1];
            var name = pars.Where(x => x.StartsWith("utm_campaign")).FirstOrDefault("").Split("=")[1];
            var id = pars.Where(x => x.StartsWith("utm_id")).FirstOrDefault("").Split("=")[1];
            var term = pars.Where(x => x.StartsWith("utm_term")).FirstOrDefault("").Split("=")[1];
            var content = pars.Where(x => x.StartsWith("utm_content")).FirstOrDefault("").Split("=")[1];

            var utm = new Utm(new Url(segments[0]), new Campaing(source, medium, name, id, term, content));

            return utm;
        }

        public override string ToString()
        {
            var segments = new List<string>();
            segments.AddIfNotNull("utm_source",Campaing.Source);
            segments.AddIfNotNull("utm_medium", Campaing.Medium);
            segments.AddIfNotNull("utm_campaign", Campaing.Name);
            segments.AddIfNotNull("utm_id", Campaing.Id);
            segments.AddIfNotNull("utm_term", Campaing.Term);
            segments.AddIfNotNull("utm_content", Campaing.Content);

            return $"{Url.Address}?{string.Join("&", segments)}";
        }
    }
}
