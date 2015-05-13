<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="WebApplication.WebForm1" %>
<asp:Content ID="customers" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Customer overview</title>
</head>
<body>
    <form id="form1">
        <div>
            <asp:Label ID="LabelCustomer" runat="server" Font-Size="XX-Large"
                Text="Private Customers"></asp:Label>
            <br /><br />
        </div>
        <br />

         <asp:Repeater ID="repPeople" runat="server">
            <ItemTemplate>
                <table>
                    <tr><td>Name:</td><td><asp:Label ID="txtName" runat="server" Text='<%# Eval("Name") %>' /></td></tr>
                    <tr><td>Address:</td><td><asp:Label ID="txtAddress" runat="server" Text='<%# Eval("Address") %>' /></td></tr>
                    <tr><td>Birthdate:</td><td><asp:Label ID="txtBirthdate" runat="server" Text='<%# Eval("Birthdate") %>' /></td></tr>
                    <tr><td>Phone:</td><td><asp:Label ID="txtPhone" runat="server" Text='<%# Eval("Phone") %>' /></td></tr>
                    <tr><td>Gender:</td><td><asp:Label ID="txtGender" runat="server" Text='<%# Eval("Gender") %>' /></td></tr>
                    <hr />
                </table>
         </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
    </asp:Content>
