<%@ Page Title="<%$ Resources:WebResources, ProjectList %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectPage.aspx.cs" Inherits="OnBoardingWeb.UI.ProjectPage" Culture="auto:en-US" UICulture="auto" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div class="row">
        <div class="col-md-12 form-group">
            <asp:TextBox ID="SearchTextBox" runat="server" placeholder="<%$ Resources:WebResources, SearchProject %>" CssClass="col-md-12 form-control margin-right-10"></asp:TextBox>
            <asp:Button ID="SearchButton" runat="server" Text="<%$ Resources:WebResources, Search %>" CssClass="btn btn-success" />
            <asp:Button ID="AddButton" runat="server" Text="<%$ Resources:WebResources, Add %>" CssClass="btn btn-primary" OnClick="AddButton_Click" />
        </div>
    </div>
    <br />
    <div class="row">
        <asp:GridView ID="GvProject" runat="server"
            AutoGenerateColumns="False" DataSourceID="OnBoardingDataSource"
            AllowPaging="True" PageSize="5" SelectedRowStyle-BackColor="LightGray"
            DataKeyNames="Id" OnRowUpdating="GvProject_RowUpdating"
            OnSelectedIndexChanged="GvProject_SelectedIndexChanged"
            CssClass="table table-condensed table-hover" Width="1028px">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="<%$ Resources:WebResources, Name %>" SortExpression="Name">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="Description" HeaderText="<%$ Resources:WebResources, Description %>" SortExpression="Description">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="StudyHour" HeaderText="<%$ Resources:WebResources, StudyHour %>" SortExpression="StudyHour" />
                <asp:BoundField DataField="StartDate" HeaderText="<%$ Resources:WebResources, StartDate %>" SortExpression="StartDate" DataFormatString="{0:dd/MM/yyyy}">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:CommandField ShowSelectButton="True" SelectText="<%$ Resources:WebResources, Select %>" />
                <asp:HyperLinkField Text="<%$ Resources:WebResources, Detail %>" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="ProjectDetail.aspx?Id={0}" />
            </Columns>
            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" PageButtonCount="4" NextPageText="Next" PreviousPageText="Prev" />
            <%--<RowStyle CssClass="RowStyle" />
            <HeaderStyle CssClass="HeaderStyle" />--%>
            <PagerStyle CssClass="PagerStyle" />
            <SelectedRowStyle CssClass="SelectedRowStyle" />
        </asp:GridView>
        <asp:Label ID="ErrorMessageLabel" runat="server" Text="" Visible="false" ViewStateMode="Disabled"></asp:Label>
    </div>
    <asp:EntityDataSource ID="OnBoardingDataSource" runat="server" ConnectionString="name=OnBoardingExerciseEntities" DefaultContainerName="OnBoardingExerciseEntities" EnableFlattening="False" EntitySetName="Projects" EntityTypeFilter="Project" Where="it.Active" OrderBy="it.Name" EnableUpdate="true">
    </asp:EntityDataSource>
    <asp:QueryExtender ID="SearchQueryExtender" runat="server" TargetControlID="OnBoardingDataSource">
        <asp:SearchExpression SearchType="Contains" DataFields="Name">
            <asp:ControlParameter ControlID="SearchTextBox" />
        </asp:SearchExpression>
        <asp:OrderByExpression Direction="Ascending" DataField="Name">
        </asp:OrderByExpression>
    </asp:QueryExtender>
</asp:Content>
