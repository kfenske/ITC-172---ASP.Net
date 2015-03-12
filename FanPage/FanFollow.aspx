<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FanFollow.aspx.cs" Inherits="FanFollow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fan Follow Page</title>
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <h1>Fan Follow Page</h1>
    <div id="followArtist">
        <asp:DataList ID="DataList1" runat="server">
            <ItemTemplate>
                <h2>
                    <asp:Label ID="lblArtistName" runat="server" Text='<%# Eval("ArtistName") %>'></asp:Label></h2>
                <p><strong>Web page:</strong><asp:Label ID="lblArtistWebPage" runat="server" Text='<%# Eval("ArtistWebPage") %>'></asp:Label></p>
            </ItemTemplate>
        </asp:DataList>
        
    </div>
    <div id="followGenre">
        <asp:DataList ID="DataList2" runat="server">
        <ItemTemplate>
            <h2>
                <asp:Label ID="lblGenreName" runat="server" Text='<%# Eval("GenreName") %>'></asp:Label></h2>
        </ItemTemplate>
    </asp:DataList>
    </div>
    <div id="search">
        <h2>Choose artist to follow</h2>
        <asp:DropDownList ID="FollowArtistList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <asp:Button ID="btnFollowArtist" runat="server" Text="Follow Artist" OnClick="btnFollowArtist_Click" />
        <asp:Label ID="lblArtist" runat="server" Text=""></asp:Label>
        <h2>Choose genre to follow</h2>
        <asp:DropDownList ID="FollowGenreList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <asp:Button ID="btnFollowGenre" runat="server" Text="Follow Genre" OnClick="btnFollowGenre_Click" />
        <asp:Label ID="lblGenre" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
