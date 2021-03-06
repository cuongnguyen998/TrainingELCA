﻿<%@ Page Title="<%$ Resources:WebResources, ProjectDetail %> " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectDetail.aspx.cs" Inherits="OnBoardingWeb.UI.ProjectDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to delete this item?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
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
            <asp:Button ID="btnDelete" runat="server" Text="<%$ Resources:WebResources, Delete %>" CssClass="btn btn-danger" OnClick="btnDelete_Click" OnClientClick="Confirm()" />
            <asp:Label ID="lbError" runat="server" ForeColor="Red" Text="Label"></asp:Label>
        </div>
    </div>

</asp:Content>
