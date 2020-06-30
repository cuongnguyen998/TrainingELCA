<%@ Page Title="<%$ Resources:WebResources, AddProject %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProject.aspx.cs" Inherits="OnBoardingWeb.UI.AddProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <div class="panel panel-primary">
        <div class="panel-heading">
            <%: Title %>.
        </div>
        <div class="panel-body col-lg-offset-3">
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="<%$ Resources:WebResources, Name %>"></asp:Label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtName" ID="RequiredNameValidator" runat="server" ErrorMessage="Name is required" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="<%$ Resources:WebResources, Description %>"></asp:Label>
                <textarea class="form-control" id="txtaDescription" rows="5" runat="server"></textarea>
                <%-- <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>--%>
            </div>
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="<%$ Resources:WebResources, StartDate %>"></asp:Label>
                <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                <asp:CompareValidator ID="StartDateCompareValidator" runat="server" ErrorMessage="Start date must be greater than 1900/01/01" Operator="GreaterThan" ValueToCompare="1900/01/01" Type="Date" ControlToValidate="txtStartDate" ForeColor="Red"></asp:CompareValidator>
            </div>
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="<%$ Resources:WebResources, StudyHour %>"></asp:Label>
                <asp:TextBox ID="txtStudyHour" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:CompareValidator ID="HourCompareValidator" runat="server" ErrorMessage="Study hour must be greater than 0" ValueToCompare="0" Operator="GreaterThan" ControlToValidate="txtStudyHour" ForeColor="Red"></asp:CompareValidator>
            </div>
            <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:WebResources, Save %>" CssClass="btn btn-primary" OnClick="btnSave_Click" />
            <asp:Label ID="lbError" runat="server" ForeColor="Red" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Content>
