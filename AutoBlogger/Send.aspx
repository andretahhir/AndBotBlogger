<%@ Page Title="" Language="C#" MasterPageFile="~/MainBs.Master" AutoEventWireup="true" CodeBehind="Send.aspx.cs" Inherits="AutoBlogger.Send" EnableViewState="true" %>

<%@ MasterType VirtualPath="~/MainBs.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <div class="form-group">
        <label for="tb_LinkApp">App Link</label>
        <asp:TextBox runat="server" ID="tb_LinkApp" CssClass="form-control"></asp:TextBox>
        <p class="help-block">The link should be clean.</p>
    </div>
    <div class="form-group">
        <label for="tb_Labels">Labels</label>
        <asp:TextBox runat="server" ID="tb_Labels" CssClass="form-control"></asp:TextBox>
        <p class="help-block">Insert custom labels separated by comma.</p>
    </div>

    <div class="form-group">
        <label for="tb_LinkApp">Post Type</label>
        <asp:DropDownList runat="server" CssClass="form-control" ID="DropDownListPostType">
            <asp:ListItem Selected="True">Application</asp:ListItem>
            <asp:ListItem Value="Game">Game</asp:ListItem>
            <asp:ListItem Value="TopGames">Top Games</asp:ListItem>
            <asp:ListItem Value="TopApps">Top Apps</asp:ListItem>
            <asp:ListItem Value="WeekResume">Week Resume</asp:ListItem>
        </asp:DropDownList>
    </div>

    <asp:Button ID="ButtonSendPost" runat="server" Text="Send Post" CssClass="btn btn-default" OnClick="ButtonSendPost_Click" />

    <hr />

    <div class="form-group">
        <label for="tb_LinkApp">Link to Generate</label>
        <asp:TextBox runat="server" ID="TextBoxResult" CssClass="form-control" />
    </div>
    <div class="form-group">
        <label for="tb_LinkApp">Generate Tweet</label>
        <asp:Button ID="ButtonPrepareTwitter" runat="server" Text="Prepare Twitter" CssClass="btn btn-info" OnClick="ButtonPrepareTwitter_Click" Enabled="false" />
    </div>

    <hr />

    <div class="form-group">
        <label for="tb_LinkApp">Generated Tweet</label>
        <asp:TextBox runat="server" ID="TextBoxTweet" CssClass="form-control" />
    </div>

    <asp:Button ID="ButtonShareTwitter" runat="server" Text="Send Post" CssClass="btn btn-success" OnClick="ButtonShareTwitter_Click" Enabled="false" />
</asp:Content>
