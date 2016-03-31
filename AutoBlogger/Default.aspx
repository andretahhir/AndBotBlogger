<%@ Page Title="" Language="C#" MasterPageFile="~/MainBs.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AutoBlogger.Default" EnableViewState="true" %>

<%@ MasterType VirtualPath="~/MainBs.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="col-md-4">
        <h2>Blogger</h2>
        <p>
            A simple code behaviour to make post adapted for Blogger based on a Play Store link.
            This App creates a post with the app info and a link for the download.
            Also share the post in Twitter!
        </p>
        <p><a class="btn btn-default" href="Send.aspx">Go to &raquo;</a></p>
    </div>
    <div class="col-md-4">
        <h2>Get more libraries</h2>
        <p>NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.</p>
        <p><a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301866">Learn more &raquo;</a></p>
    </div>
    <div class="col-md-4">
        <h2>Web Hosting</h2>
        <p>You can easily find a web hosting company that offers the right mix of features and price for your applications.</p>
        <p><a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301867">Learn more &raquo;</a></p>
    </div>

    <hr />

    <asp:Button ID="Buttonoftest1" runat="server" Text="The Button with Tests" CssClass="btn btn-danger" OnClick="Buttonoftest1_Click" />
</asp:Content>