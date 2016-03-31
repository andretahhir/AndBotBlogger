using AutoBlogger.Controllers;
using AutoBlogger.Models;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace AutoBlogger
{
    public static class PostHandler
    {
        public static Post PostBuild(string Code, string Link, PostType postType, IList<string> Labels)
        {
            Post result = null;
            Token token = TokenHandler.RequestGoogleToken(Code);

            // TODO: Save token and enable refresh
            //Helper.Serialize(token);
            //Token token = Helper.DeSerialize();

            if (Labels == null)
            {
                Labels = new List<string>();
            }

            Labels.Add(postType.ToString());

            if (token != null)
            {
                List<string> res = DownloadHtml(Link);
                Post x = GetContent(res, Link, Labels);
                x.PostType = postType;
                Blog y = BloggerHandler.GetBlogByUrl(Credentials.BlogToUse);
                result = BloggerHandler.InsertPost(token, x, y);
            }

            return result;
        }

        // Change it to private after tests
        private static List<string> DownloadHtml(string link)
        {
            List<string> result = new List<string>();
            WebClient client = new WebClient();
            Stream data = client.OpenRead(link);
            StreamReader reader = new StreamReader(data);
            string htmlDownloaded = reader.ReadToEnd();
            data.Close();
            reader.Close();

            // Image download

            string beginImageSplit = "<img class=\"cover-image\" src=\"";
            string endImageSplit = "\" alt=\"Cover art\" aria-hidden=\"true\" itemprop=\"image\"";

            int startImage = htmlDownloaded.IndexOf(beginImageSplit);
            startImage = startImage + beginImageSplit.Length;
            int endImage = htmlDownloaded.IndexOf(endImageSplit, startImage);
            string resultImage = htmlDownloaded.Substring(startImage, endImage - startImage);

            result.Add(resultImage);

            // Image download

            string beginTitleSplit = "document-title\" itemprop=\"name\"> <div>";
            string endTitleSplit = "</div> </div> <div itemprop=\"author";

            int startTitle = htmlDownloaded.IndexOf(beginTitleSplit);
            startTitle = startTitle + beginTitleSplit.Length;
            int endTitle = htmlDownloaded.IndexOf(endTitleSplit, startTitle);
            string resultTitle = htmlDownloaded.Substring(startTitle, endTitle - startTitle);

            result.Add(resultTitle);

            return result;
        }

        private static Post GetContent(List<string> list, string link, IList<string> labels)
        {
            string withTemplate =

            "<div class=\"separator\" style=\"clear:both; text-align:center; \">" +
            "<img border=\"0\" height=\"200\" src =\"[Img1]\" width=\"200\" />" +
            "</div>" +
            "[Descrip1] <br />" +
            "<!--more--> <br />" +
            "<div class=\"separator\" style=\"clear:both; text-align:center;\">" +
            "<a href=\"[LinkStore1]\" target=\"_blank\">" +
            "<img border=\"0\" src=\"http://3.bp.blogspot.com/-R_JIVFswrB4/VlMMInfMObI/AAAAAAAABJU/YN2xlPiCnnU/s1600/download_bottun.png\" /></a>" +
            "</div>" +
            "<br />";

            withTemplate = withTemplate.Replace("[Img1]", list[0]);
            withTemplate = withTemplate.Replace("[Descrip1]", list[1]);
            withTemplate = withTemplate.Replace("[LinkStore1]", link);

            Post result = new Post();
            result.Content = withTemplate;
            result.Title = list[1];
            result.Labels = labels;

            return result;
        }

        public static string PrepareTwitter(Post LastPost, UrlShortener Url)
        {
            string tweet = string.Empty;
            tweet = "#New Post: " + LastPost.Title + " " + Url.ShortUrl + " ";
            foreach (var item in LastPost.Labels)
            {
                tweet += " #" + item;
            }
            return tweet;
        }
    }
}