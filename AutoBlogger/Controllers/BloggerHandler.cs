using AutoBlogger.Controllers;
using AutoBlogger.Models;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace AutoBlogger
{
    public class BloggerHandler
    {
        public static Blog GetBlogByUrl(string Url)
        {
            Blog blog = null;
            try
            {
                //Logger.LogInfo("GetBlogByUrl", "Get blog...");

                var client = new RestClient("https://www.googleapis.com");
                var request = new RestRequest("/blogger/v3/blogs/byurl");
                request.AddParameter("url", Url);
                request.AddParameter("key", Credentials.ApiKey);

                var response = client.Execute(request);
                blog = JsonConvert.DeserializeObject<Blog>(response.Content);
            }
            catch (Exception ex)
            {
                //Logger.LogError("GetBlogByUrl", ex.Message);
            }

            return blog;
        }

        public static Post InsertPost(Token CurrentToken, Post NewPost, Blog CurrentBlog)
        {
            Post post = null;
            try
            {
                //Logger.LogInfo("InsertPost", "Inserting post...");

                var client = new RestClient("https://www.googleapis.com");
                var request = new RestRequest("/blogger/v3/blogs/" + CurrentBlog.Id + "/posts", Method.POST);
                request.RequestFormat = DataFormat.Json;
                request.AddHeader("Authorization", string.Format("{1} {0}", CurrentToken.AcessToken, CurrentToken.TokenType));
                request.AddHeader("Content-type", "application/json");
                request.AddBody(new
                {
                    title = NewPost.PostType.ToString() + ": " + NewPost.Title,
                    content = NewPost.Content,
                    labels = NewPost.Labels
                });

                var response = client.Execute(request);
                post = JsonConvert.DeserializeObject<Post>(response.Content);
            }
            catch (Exception ex)
            {
                //Logger.LogError("InsertPost", ex.Message);
            }

            return post;
        }
    }
}