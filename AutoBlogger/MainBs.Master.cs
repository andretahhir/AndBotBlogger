using AutoBlogger.Controllers;
using AutoBlogger.Models;
using System;
using System.Web.UI;

namespace AutoBlogger
{
    public partial class MainBs : MasterPage
    {
        public const string ConstantCode = "code";

        public string Code
        {
            get
            {
                if (Session["codeKey"] == null)
                    return null;
                else
                    return Session["codeKey"].ToString();
            }
        }

        public string PageTitle
        {
            set
            {
                LabelTitle.Text = value;
            }
        }

        public string PageDescrip
        {
            set
            {
                LabelDescription.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request[ConstantCode]))
                Session.Add("codeKey", Request[ConstantCode]);
            if (Code != null)
            {
                LinkButtonLogIn.Enabled = false;
                Label1.Text = "Logged";
            }
            else
            {
                LinkButtonLogIn.Enabled = true;
                Label1.Text = "Not Log";
            }
        }

        protected void LinkButtonLogIn_Click(object sender, EventArgs e)
        {
            if (Code == null)
            {
                string responseKey = string.Empty;
                responseKey = TokenHandler.RequestGoogleCode();

                if (!string.IsNullOrEmpty(responseKey))
                {
                    Response.Redirect(responseKey);
                }
            }
        }
    }
}