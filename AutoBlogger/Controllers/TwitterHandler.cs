using AutoBlogger.Models;
using System;
using System.Collections.Generic;
using TinyTwitter;

namespace AutoBlogger.Controllers
{
    public class TwitterHandler
    {
        private static TinyTwitter.TinyTwitter _tinyTwitter;

        private static TinyTwitter.TinyTwitter ExistentTinyTwitter
        {
            get
            {
                if (_tinyTwitter == null)
                {
                    var oauth = new OAuthInfo
                    {
                        AccessToken = Credentials.TwitterToken,
                        AccessSecret = Credentials.TwitterTokenSecret,
                        ConsumerKey = Credentials.TwitterConsumerKey,
                        ConsumerSecret = Credentials.TwitterConsumerSecret
                    };

                    _tinyTwitter = new TinyTwitter.TinyTwitter(oauth);
                }

                return _tinyTwitter;
            }
        }

        public static bool SendANewTwitter(string Tweet)
        {
            bool result = false;
            try
            {
                if (Tweet != null && !string.IsNullOrEmpty(Tweet.Trim()))
                {
                    ExistentTinyTwitter.UpdateStatus(Tweet);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static bool SendANewTwitter(string Tweet, List<string> hashtags)
        {
            bool result = false;
            try
            {
                foreach (string item in hashtags)
                {
                    Tweet += " #" + item;
                }

                if (Tweet != null && !string.IsNullOrEmpty(Tweet.Trim()))
                {
                    ExistentTinyTwitter.UpdateStatus(Tweet);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        //public static void SendANewTwitter()
        //{
        //    var oauth = new OAuthInfo
        //    {
        //        AccessToken = Credentials.TwitterToken,
        //        AccessSecret = Credentials.TwitterTokenSecret,
        //        ConsumerKey = Credentials.TwitterConsumerKey,
        //        ConsumerSecret = Credentials.TwitterConsumerSecret
        //    };

        //    var twitter = new TinyTwitter.TinyTwitter(oauth);

        //    // Update status, i.e, post a new tweet
        //    twitter.UpdateStatus("I'm tweeting from C#");

        //    // Get home timeline tweets
        //    var tweets = twitter.GetHomeTimeline();

        //    foreach (var tweet in tweets)
        //        Console.WriteLine("{0}: {1}", tweet.UserName, tweet.Text);
        //}
    }
}