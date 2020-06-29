<%@ Page Title="Project List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectPage.aspx.cs" Inherits="OnBoardingWeb.UI.ProjectPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div class="row">
        <div class="col-md-12 form-group">
            <asp:TextBox ID="SearchTextBox" runat="server" placeholder="Search project" CssClass="col-md-12 form-control"></asp:TextBox>
            <asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" CssClass="btn btn-success" />
        </div>
    </div>
    <br />
    <div class="row">
        <asp:GridView ID="GvProject" runat="server" 
            AutoGenerateColumns="False" DataSourceID="OnBoardingDataSource" 
            AllowPaging="True" PageSize="5" SelectedRowStyle-BackColor="LightGray" 
            DataKeyNames="Id" OnRowUpdating="GvProject_RowUpdating" 
            OnSelectedIndexChanged="GvProject_SelectedIndexChanged" 
            CssClass="GridViewStyle" Width="1028px">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="StudyHour" HeaderText="StudyHour" SortExpression="StudyHour" />
                <asp:BoundField DataField="StartDate" HeaderText="StartDate" SortExpression="StartDate" DataFormatString="{0:dd/MM/yyyy}">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:CommandField ShowSelectButton="True" />
                <asp:HyperLinkField Text="Detail" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="ProjectDetail.aspx?Id={0}" />
            </Columns>
            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" PageButtonCount="4" NextPageText="Next" PreviousPageText="Prev" />
            <%--<SelectedRowStyle BackColor="LightGray"></SelectedRowStyle>--%>
            <RowStyle CssClass="RowStyle" />
            <HeaderStyle CssClass="HeaderStyle" />
            <PagerStyle CssClass="PagerStyle" />
            <SelectedRowStyle CssClass="SelectedRowStyle" />
        </asp:GridView>
        <asp:Label ID="ErrorMessageLabel" runat="server" Text="" Visible="false" ViewStateMode="Disabled"></asp:Label>
    </div>
    <asp:EntityDataSource ID="OnBoardingDataSource" runat="server" ConnectionString="name=OnBoardingExerciseEntities" DefaultContainerName="OnBoardingExerciseEntities" EnableFlattening="False" EntitySetName="Projects" EntityTypeFilter="Project" OrderBy="it.Name" EnableUpdate="true">
    </asp:EntityDataSource>
    <asp:QueryExtender ID="SearchQueryExtender" runat="server" TargetControlID="OnBoardingDataSource">
        <asp:SearchExpression SearchType="Contains" DataFields="Name">
            <asp:ControlParameter ControlID="SearchTextBox" />
        </asp:SearchExpression>
        <asp:OrderByExpression Direction="Ascending" DataField="Name">
        </asp:OrderByExpression>
    </asp:QueryExtender>
</asp:Content>
