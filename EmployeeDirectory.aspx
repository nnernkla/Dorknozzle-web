<%@ Page Title="" Language="C#" MasterPageFile="~/DorknozzleMasterPage.master" AutoEventWireup="true" CodeFile="EmployeeDirectory.aspx.cs" Inherits="EmployeeDirectory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>Employee Directory</h1>
<!-- ItemTemplate specifies makeup to be output for each item in the data source. If written as
part of an HTML table, this template would contain the <td> and </td> tags and their commants -->
<!--Separator Template provides makeup to appear between the items in the data source. It will not
appear before the first or after the last item -->
        <asp:Repeater ID="rdrEmployeesRepeater" runat="server">
        <ItemTemplate>
            Employer ID:<strong><%#Eval("EmployeeID")%></strong><br />
            Name:<strong><%#Eval("Name")%></strong><br />
            Username:<strong><%#Eval("Username")%></strong><br />
        </ItemTemplate>
        <SeparatorTemplate>
        <!--the following item appears between each data group -->
        <hr />
        </SeparatorTemplate>
        </asp:Repeater>
</asp:Content>

 