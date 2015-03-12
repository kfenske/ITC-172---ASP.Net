<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FanPage.aspx.cs" Inherits="FanPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fan Search Page</title>
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Fan Search</h1>
        <h2>Artists</h2>
        <asp:DropDownList ID="ArtistList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ArtistList_SelectedIndexChanged"></asp:DropDownList>
        <asp:GridView ID="ArtistGrid" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField ReadOnly="true" HeaderText="Show Name" DataField="ShowName" />
                <asp:BoundField ReadOnly="true" HeaderText="Artist Name" DataField="ArtistName" />
                <asp:BoundField ReadOnly="true" HeaderText="Venue Name" DataField="VenueName" />
                <asp:BoundField ReadOnly="true" HeaderText="Show Time" DataField="ShowTime" />
            </Columns>
        </asp:GridView>

        <h2>Genres</h2>
        <asp:DropDownList ID="GenreList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="GenreList_SelectedIndexChanged"></asp:DropDownList>
        <asp:GridView ID="GenreGrid" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField ReadOnly="true" HeaderText="Artist Name" DataField="ArtistName"/>
                <asp:BoundField ReadOnly="true" HeaderText="Artist Web Page" DataField="ArtistWebPage"/>
            </Columns>
        </asp:GridView>

        <h2>Venues</h2>
        <asp:DropDownList ID="VenueList" runat="server" AutoPostBack ="true" OnSelectedIndexChanged="VenueList_SelectedIndexChanged"></asp:DropDownList>
        <asp:GridView ID="VenueGrid" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField ReadOnly="true" HeaderText="Venue Name" DataField="VenueName" />
                <asp:BoundField ReadOnly="true" HeaderText="Street Address" DataField="VenueAddress" />
                <asp:BoundField ReadOnly="true" HeaderText="City" DataField="VenueCity" />
                <asp:BoundField ReadOnly="true" HeaderText="State" DataField="VenueState" />
                <asp:BoundField ReadOnly="true" HeaderText="Phone" DataField="VenuePhone" />
                <asp:BoundField ReadOnly="true" HeaderText="Web page" DataField="VenueWebPage" />
            </Columns>
        </asp:GridView>
    </div>
    <div id="footer">
        <asp:LinkButton ID="lbFollow" runat="server" PostBackUrl="~/FanFollow.aspx">My Fan Page</asp:LinkButton>
    </div>
    </form>
</body>
</html>
