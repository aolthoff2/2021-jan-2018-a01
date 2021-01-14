<%@ Page Title="Filter Search DEMO" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchByDDL.aspx.cs" Inherits="WebApp.SamplePages.SearchByDDL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>SEARCH ALBUMS BY ARTIST</h1>

    <div class="row">
        <div class="offset-3">
            <asp:Label ID="Label1" runat="server" Text="SELECT AN ARTIST"></asp:Label>&nbsp;&nbsp;
            <asp:DropDownList ID="ArtistList" runat="server">
            </asp:DropDownList>&nbsp&nbsp;
            <asp:LinkButton ID="SearchAlbums" runat="server" OnClick="SearchAlbums_Click"><i class="fa fa-search"></i>&nbsp;SEARCH</asp:LinkButton>
        </div>
    </div>
    <br />
    <br />
    <div class="row">
        <div class="offset-3">
            <asp:Label ID="MessageLabel" runat="server"></asp:Label>
        </div>
    </div>
    <br />
    <br />
    <div class="row">
        <div class="offset-3">
            <asp:GridView ID="ArtistAlbumList" runat="server"
                AutoGenerateColumns="False"
                CssClass="table table-striped"
                GridLines="Horizontal"
                BorderStyle="None">
                <Columns>
                    <asp:TemplateField HeaderText="ALBUM">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="RELEASED">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("ReleaseYear") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ARTIST">
                        <ItemTemplate>
                            <asp:DropDownList ID="ArtistNameList" runat="server" 
                                DataSourceID="ArtistNameListODS" 
                                DataTextField="DisplayField" 
                                DataValueField="ValueField" Width="250px"
                                selectedvalue='<%# Eval("ArtistID") %>'>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    NO ALBUMS FOR SELECTED ARTIST.
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:ObjectDataSource ID="ArtistNameListODS" runat="server" 
                OldValuesParameterFormatString="original_{0}" 
                SelectMethod="Artists_DDLList" TypeName="ChinookSystem.BLL.ArtistController">
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
