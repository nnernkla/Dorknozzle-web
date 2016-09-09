<%@ Page Title="" Language="C#" MasterPageFile="~/DorknozzleMasterPage.master" AutoEventWireup="true" CodeFile="AddressBook.aspx.cs" Inherits="AddressBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>Address Book</h1>
<!--Create a GridView control to present a listing of all records in the database table-->
    <asp:GridView ID="grid" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="grid_SelectedIndexChanged" >
    <Columns>
        <asp:BoundField DataField="Name" HeaderText="Name" />
        <asp:BoundField DataField="City" HeaderText="City" />
        <asp:BoundField DataField="MobilePhone" HeaderText="MobilePhone" />
        <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Select" />
    </Columns>
    </asp:GridView>
     
    <br />
    <!-- Create a DetailsView control to present an expanded list of data for a specific database record. -->
    <asp:DetailsView ID="employeeDetails" runat="server" AutoGenerateRows="false">
    <Fields>
        <asp:BoundField DataField="Address" HeaderText="Address" />
        <asp:BoundField DataField="City" HeaderText="City" />
        <asp:BoundField DataField="State" HeaderText="State" />
        <asp:BoundField DataField="Zip" HeaderText="Zip" />
        <asp:BoundField DataField="HomePhone" HeaderText="Home Phone" />
        <asp:BoundField DataField="Extension" HeaderText="Extension" />
    </Fields>
    <HeaderTemplate>
        <%#Eval("Name")%>
    </HeaderTemplate>

    </asp:DetailsView>
    
  </asp:Content>

