<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewShow.aspx.cs" Inherits="NewShow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add a New Show</title>
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Schedule a show at your venue!</h1>
        
        <asp:Table ID="tblArtist" runat="server">
            <asp:TableRow>
                <asp:TableCell>Name:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtArtName" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Email:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtArtEmail" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Web page:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtArtWebPage" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btnAddArtist" runat="server" Text="Save Artist" OnClick="btnAddArtist_Click" CssClass="button" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblSaveArtist" runat="server" Text="Save artist before entering in the show"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Label ID="lblArtistKey" runat="server" Text="" Visible="false"></asp:Label>
        <br />
        <br />
        <table>
            <tr>
                <td>Select the artist</td>
                <td>
                    <asp:DropDownList ID="dlArtist" runat="server" OnSelectedIndexChanged="dlArtist_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Name:</td>
                <td>
                    <asp:TextBox ID="txtShowName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Time:</td>
                <td>
                    <asp:TextBox ID="txtTime" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Date:</td>
                <td>
                    <asp:Calendar ID="calDate" runat="server"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td>Ticket Info:</td>
                <td>
                    <asp:TextBox ID="txtTicketInfo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Set start time:</td>
                <td>
                    <asp:TextBox ID="txtStartTime" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Additional details:</td>
                <td>
                    <asp:TextBox ID="txtDetails" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <p><asp:Button ID="btnAddShow" runat="server" Text="Add Show" OnClick="btnAddShow_Click" CssClass="button" CausesValidation="false" /></p>
        <p><asp:Label ID="lbMessage" runat="server" Text=""></asp:Label></p>
    </div>
    </form>
</body>
</html>
