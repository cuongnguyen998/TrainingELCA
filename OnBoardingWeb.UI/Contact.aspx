<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="OnBoardingWeb.UI.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:DropDownList ID="ddlLanguage" runat="server" AutoPostBack="true">
            <asp:ListItem Text="English" Value="en-US" />
            <asp:ListItem Text="Germany" Value="de-DE" />
        </asp:DropDownList>
    <asp:Label ID="LabelLanguge" runat="server" Text="<%$ Resources:WebResources, Home %>"></asp:Label>
</asp:Content>
