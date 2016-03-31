using System;

namespace AutoBlogger
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.PageTitle = "";
            Master.PageDescrip = "";
        }

        protected void Buttonoftest1_Click(object sender, EventArgs e)
        {
            //Controllers.TokenHandler.RefreshGoogleToken();
            //string result = Controllers.UrlShortenerHandler.InsertUrlShortner("http://andcorreia.eu/", Master.Code);
        }
    }
}