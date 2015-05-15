<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Vehicles.aspx.cs" Inherits="WebApplication.Vehicle" %>
<asp:Content ID="vehicles" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Vehicle overview</title>
</head>
<body>
    <form id="form2">
        <div>
            <asp:Label ID="LabelVehicle" runat="server" Font-Size="XX-Large"
                Text="Cars"></asp:Label>
            <br /><br />
        </div>
        <br />

         <asp:Repeater ID="repVehicles" runat="server">
            <ItemTemplate>
                <table>
                    <tr><td>Model:</td><td><asp:Label ID="txtModel" runat="server" Text='<%# Eval("Model") %>' /></td></tr>
                    <tr><td>Color:</td><td><asp:Label ID="txtColor" runat="server" Text='<%# Eval("Color") %>' /></td></tr>
                    <tr><td>Sales price:</td><td><asp:Label ID="txtSalesPrice" runat="server" Text='<%# Eval("SalesPrice") %>' /></td></tr>
                    <tr><td>Rent price:</td><td><asp:Label ID="txtRentPrice" runat="server" Text='<%# Eval("RentPrice") %>' /></td></tr>
                    <tr><td>Car state::</td><td><asp:Label ID="txtCarState" runat="server" Text='<%# Eval("CarState") %>' /></td></tr>
                    <hr />
                </table>
         </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
    </asp:Content>
