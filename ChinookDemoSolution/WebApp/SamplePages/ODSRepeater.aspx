<%@ Page Title="Repeater with Nested Query" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ODSRepeater.aspx.cs" Inherits="WebApp.SamplePages.ODSRepeater" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        REPEATER WITH NESTED QUERY
    </h1>
    <div class="row">
        <div class="offset-2">
            <uc1:MessageUserControl runat="server" ID="MessageUserControl" />
        </div>
    </div>
    <div class="row">
        <div class="offset-2">
            <asp:Repeater ID="EmployeeCustomers" runat="server" DataSourceID="EmployeeCustomersODS"
                 ItemType="ChinookSystem.VIEWMODELS.EmployeeCustomerList">
                <HeaderTemplate>
                    <h3>Sales Support Employees</h3>
                </HeaderTemplate>
                <ItemTemplate>
                    <%# Item.EmployeeName %> (<%# Item.Title %>) has <%# Item.CustomersSupportCount %> customers<br /><br />
<%--                    <asp:GridView ID="SupportedCustomersofEmployee" runat="server"
                         DataSource="<%# Item.CustomerList %>" 
                         ItemType="ChinookSystem.VIEWMODELS.CustomerSupportItem">

                    </asp:GridView>--%>
                    <asp:Repeater ID="SupportedCustomersofEmployee" runat="server"
                          DataSource="<%# Item.CustomerList %>"
                         ItemType="ChinookSystem.VIEWMODELS.CustomerSupportItem">
                        <ItemTemplate>
                            Name: <%# Item.CustomerName %>&nbsp;&nbsp;
                            Phone: <%# Item.Phone %>&nbsp;&nbsp;
                            City: <%# Item.City %>&nbsp;&nbsp;
                            State: <%# Item.State %><br />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>

            </asp:Repeater>
            <asp:ObjectDataSource ID="EmployeeCustomersODS" runat="server" 
                OldValuesParameterFormatString="original_{0}" 
                SelectMethod="Employee_EmployeeCustomerList" 
                TypeName="ChinookSystem.BLL.EmployeeController">
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
