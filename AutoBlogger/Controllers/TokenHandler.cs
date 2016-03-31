using AutoBlogger.Models;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace AutoBlogger.Controllers
{
    public class TokenHandler
    {
        public static string RequestGoogleCode()
        {
            string res = string.Empty;
            try
            {
                //Logger.LogInfo("RequestGoogleCode", "Requesting code...");

                var client = new RestClient("https://accounts.google.com");
                var request = new RestRequest("/o/oauth2/auth", Method.GET);
                request.AddParameter("access_type", "offline");
                request.AddParameter("approval_prompt", "force");
                request.AddParameter("scope", Credentials.Scopes);
                request.AddParameter("response_type", "code");
                request.AddParameter("redirect_uri", Credentials.GoogleRedirect);
                request.AddParameter("client_id", Credentials.GoogleClientId);

                var response = client.Execute(request);
                res = response.ResponseUri.AbsoluteUri;

                if (string.IsNullOrEmpty(res))
                {
                    //Logger.LogError("RequestGoogleCode", "Uri is empty...");
                    return res;
                }
            }
            catch (Exception ex)
            {
                //Logger.LogError("RequestGoogleCode", ex.Message);
            }
            return res;
        }

        public static Token RequestGoogleToken(string Code)
        {
            Token token = null;

            if (string.IsNullOrEmpty(Code))
            {
                //Logger.LogError("RequestGoogleToken", "Code is empty...");
                return token;
            }

            try
            {
                //Logger.LogInfo("RequestGoogleToken", "Requesting token...");

                token = Helper.DeSerialize();

                if (token == null || token.AcessToken == null)
                {
                    var client = new RestClient("https://www.googleapis.com");
                    var request = new RestRequest("/oauth2/v3/token", Method.POST);
                    request.RequestFormat = DataFormat.Json;
                    request.AddParameter("code", Code);
                    request.AddParameter("redirect_uri", Credentials.GoogleRedirect);
                    request.AddParameter("client_id", Credentials.GoogleClientId);
                    request.AddParameter("client_secret", Credentials.GoogleClientSecret);
                    request.AddParameter("grant_type", "authorization_code");

                    var response = client.Execute(request);
                    token = JsonConvert.DeserializeObject<Token>(response.Content);

                    if (token != null)
                        Helper.Serialize(token);
                }
                else if (token.RefreshToken != null)
                {
                    token = RefreshGoogleToken(token);
                }
                else
                {
                    //Logger.LogError("RequestGoogleToken", "No refresh token found...");
                    return token;
                }
            }
            catch (Exception ex)
            {
                //Logger.LogError("RequestGoogleToken", ex.Message);
            }

            return token;
        }

        public static Token RefreshGoogleToken(Token CurrentToken)
        {
            Token token = null;
            try
            {
                //Logger.LogInfo("RefreshGoogleToken", "Refreshing token...");

                var client = new RestClient("https://www.googleapis.com");
                var request = new RestRequest("/oauth2/v4/token", Method.POST);
                request.RequestFormat = DataFormat.Json;

                request.AddParameter("client_id", Credentials.GoogleClientId);
                request.AddParameter("client_secret", Credentials.GoogleClientSecret);
                request.AddParameter("refresh_token", CurrentToken.RefreshToken);
                request.AddParameter("grant_type", "refresh_token");

                var response = client.Execute(request);
                token = JsonConvert.DeserializeObject<Token>(response.Content);
            }
            catch (Exception ex)
            {
                //Logger.LogError("RefreshGoogleToken", ex.Message);
            }

            return token;
        }
    }
}