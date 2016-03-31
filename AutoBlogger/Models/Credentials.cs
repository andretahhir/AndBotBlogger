namespace AutoBlogger.Models
{
    public class Credentials
    {
        // TODO: Change to a options file

        public static string BlogToUse { get { return "blog link"; } }

        /*****=> Google Credentials <=*****/
        // https://console.developers.google.com/

        public static string GoogleClientId { get { return "client id here"; } }

        public static string GoogleClientSecret { get { return "client secret"; } }

        public static string ApiKey { get { return "api key"; } }

        public const string Scopes = "https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/blogger https://www.googleapis.com/auth/urlshortener";

        /// <summary>
        /// This property should be the same as the URL defined in the Google Console
        /// </summary>
        public static string GoogleRedirect { get { return "configured redirect here"; } }

        /*****=> Twitter Credentials <=*****/

        public static string TwitterConsumerKey { get { return "consumer key"; } }

        public static string TwitterConsumerSecret { get { return "consumer secret"; } }

        public static string TwitterToken { get { return "twitter token"; } }

        public static string TwitterTokenSecret { get { return "token secret"; } }
    }
}