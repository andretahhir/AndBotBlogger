using AutoBlogger.Models;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace AutoBlogger.Controllers
{
    public static class UrlShortenerHandler
    {
        public static UrlShortener InsertUrlShortner(string Link, string Code)
        {
            UrlShortener urlShortener = null;
            try
            {
                //Logger.LogInfo("InsertUrlShortner", "Generating short url...");
                Token token = TokenHandler.RequestGoogleToken(Code);

                var client = new RestClient("https://www.googleapis.com");
                var request = new RestRequest("/urlshortener/v1/url", Method.POST);
                request.RequestFormat = DataFormat.Json;
                request.AddHeader("Authorization", string.Format("{1} {0}", token.AcessToken, token.TokenType));
                request.AddHeader("Content-type", "application/json");
                request.AddBody(new
                {
                    longUrl = Link
                });

                var response = client.Execute(request);
                urlShortener = JsonConvert.DeserializeObject<UrlShortener>(response.Content);
            }
            catch (Exception ex)
            {
                //Logger.LogError("InsertUrlShortner", ex.Message);
            }

            return urlShortener;
        }
    }
}