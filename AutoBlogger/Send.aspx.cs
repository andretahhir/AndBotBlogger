using AutoBlogger.Controllers;
using AutoBlogger.Models;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace AutoBlogger
{
    public partial class Send : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.PageTitle = "Send";
            Master.PageDescrip = "Insert a Play Store link to send a new post";
            //if (string.IsNullOrEmpty(Master.Code))
            //    Response.Redirect("~/Default.aspx");
        }

        protected void ButtonSendPost_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_LinkApp.Text.Trim()))
            {
                TextBoxResult.Text = "Fill the app link!";
            }
            else if (GetOptionSelected() == PostType.None)
            {
                TextBoxResult.Text = "Select a post type";
            }
            else
            {
                Post post = PostHandler.PostBuild(Master.Code, CheckAppLink(tb_LinkApp.Text), GetOptionSelected(), GetLabels(tb_Labels.Text));
                if (post != null && post.Live)
                {
                    TextBoxResult.Text = post.Url;
                    tb_LinkApp.Text = string.Empty;
                    tb_Labels.Text = string.Empty;
                    ButtonPrepareTwitter.Enabled = true;
                    Session["lastPost"] = post;
                }
            }
        }

        private PostType GetOptionSelected()
        {
            PostType res;
            if (DropDownListPostType.SelectedValue == "Game")
                res = PostType.Game;
            else if (DropDownListPostType.SelectedValue == "Application")
                res = PostType.Application;
            else if (DropDownListPostType.SelectedValue == "TopGames")
                res = PostType.TopGames;
            else if (DropDownListPostType.SelectedValue == "TopApps")
                res = PostType.TopApps;
            else
                res = PostType.None;

            return res;
        }

        private string CheckAppLink(string Link)
        {
            // The '&hl=en' make the language as english
            return Link + "&hl=en";
        }

        private IList<string> GetLabels(string LabelField)
        {
            IList<string> reslist = null;
            if (!string.IsNullOrEmpty(LabelField.Trim()))
            {
                reslist = new List<string>();
                string[] array = LabelField.Split(',');
                foreach (string item in array)
                {
                    reslist.Add(item);
                }
            }
            return reslist;
        }

        protected void ButtonPrepareTwitter_Click(object sender, EventArgs e)
        {
            UrlShortener url = UrlShortenerHandler.InsertUrlShortner(TextBoxResult.Text, Master.Code);
            var post = Session["lastPost"] as Post;
            if (post != null)
            {
                TextBoxTweet.Text = PostHandler.PrepareTwitter(post, url);
                ButtonShareTwitter.Enabled = true;
            }
        }

        protected void ButtonShareTwitter_Click(object sender, EventArgs e)
        {
            bool res = TwitterHandler.SendANewTwitter(TextBoxTweet.Text);
            if (res)
                TextBoxTweet.Text = "SENT!!";
        }
    }
}