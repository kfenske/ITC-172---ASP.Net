<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Venue Registration</h1>
        <table>
            <tr>
                <td>Name:</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Email:</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Web page:</td>
                <td>
                    <asp:TextBox ID="txtWebPage" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Address:</td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>City:</td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>State:</td>
                <td>
                    <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Zip code:</td>
                <td>
                    <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Phone:</td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Username:</td>
                <td>
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Password:</td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Confirm password:</td>
                <td>
                    <asp:TextBox ID="txtConfPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" CssClass="button" />
                </td>
                <td>
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="lbLogin" runat="server" PostBackUrl="~/Default.aspx">Login</asp:LinkButton>
                </td>
            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
