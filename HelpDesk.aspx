
<%@ Page Title="Help Desk" Language="C#" MasterPageFile="~/DorknozzleMasterPage.master" AutoEventWireup="true" CodeFile="HelpDesk.aspx.cs" Inherits="HelpDesk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!-- Create textbox, DropDrowList, button control and some validation controls to the page-->
     <p>
            Station Number:&nbsp;
            <br />
            <asp:TextBox ID="txtStation" runat="server" CssClass="textbox"></asp:TextBox>
            <!--Add RequiredFieldValidator control to check that textbox cannot be empty-->
            <asp:RequiredFieldValidator ID="stationNumReq" runat="server" Display="Dynamic"
             ErrorMessage="<br/>You must enter a station number!" ControlToValidate = "txtStation"></asp:RequiredFieldValidator>
             <!--Add CompareValidator control to compare if the input data is a valid number -->
            <asp:CompareValidator ID="stationNumCheck" runat="server" Display="Dynamic" Operator="DataTypeCheck" Type="Integer"
             ErrorMessage="The value must be a number!" ControlToValidate = "txtStation"></asp:CompareValidator>
            <!--Add RangeValidator control to check if input data is a numberal between 1 and 50 -->
            <asp:RangeValidator ID="stationNumRangeCheck" runat="server" Display="Dynamic" Type="Integer" MinimumValue="1" MaximumValue="50"
             ErrorMessage="Number must be between 1 to 50." ControlToValidate = "txtStation"></asp:RangeValidator>
    </p>
     <p>
            <br />
            Problem Category:&nbsp;
            <br />
            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="dropdownmenu">
            </asp:DropDownList>&nbsp;&nbsp;
     </p>
     <p>
            Problem Subject:&nbsp;
            <br />
            <asp:DropDownList ID="ddlSubject" runat="server" CssClass="dropdownmenu">
            </asp:DropDownList>
     </p>
     <p>
            Problem Description:&nbsp;
            <br />
            <asp:TextBox ID="txtDescription" runat="server" CssClass="textbox" Rows="40" TextMode="MultiLine" 
            Columns="40"></asp:TextBox>
            <!--Add RequiredFieldValidator control to check that textbox cannot be empty-->
            <asp:RequiredFieldValidator ID="descriptionReq" runat="server" Display="Dynamic"
             ErrorMessage="<br/>You must enter a description!" ControlToValidate = "txtDescription"></asp:RequiredFieldValidator>
     </p>
     <p id="bottons">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit Request" 
                CssClass="button" onclick="btnSubmit_Click"/>
      </p>
</asp:Content>

