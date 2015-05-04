<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Landmandens Cardealership</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Font-Size="XX-Large"
                Text="Welcome to Landmanden&#39;s Cardealer Site!"></asp:Label>
            <br /><br />
        </div>
        
        <asp:Label runat="server" Font-Size="Large" Text="Private Customers:"></asp:Label>
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
