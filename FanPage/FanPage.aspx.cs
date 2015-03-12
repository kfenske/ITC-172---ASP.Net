using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FanPage : System.Web.UI.Page
{
    FanLoginService.FanLoginServiceClient fan = new FanLoginService.FanLoginServiceClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<FanLoginService.Artist> artistList = fan.GetArtist().ToList();
            ArtistList.DataSource = artistList;
            ArtistList.DataTextField = "ArtistName";
            ArtistList.DataBind();

            List<FanLoginService.Genre> genreList = fan.GetGenre().ToList();
            GenreList.DataSource = genreList;
            GenreList.DataTextField = "GenreName";
            GenreList.DataBind();

            List<string> venueList = fan.GetVenue().ToList();
            VenueList.DataSource = venueList;
            VenueList.DataBind();
        }
    }
    protected void ArtistList_SelectedIndexChanged(object sender, EventArgs e)
    {
        string serv = ArtistList.SelectedItem.Text;
        List<FanLoginService.ShowInfo> shows = fan.ArtistShows(serv).ToList();
        ArtistGrid.DataSource = shows;
        ArtistGrid.DataBind();
    }
    protected void GenreList_SelectedIndexChanged(object sender, EventArgs e)
    {
        string serv = GenreList.SelectedItem.Text;
        List<FanLoginService.Artist> artists = fan.GetArtists(serv).ToList();
        GenreGrid.DataSource = artists;
        GenreGrid.DataBind();
    }

    protected void VenueList_SelectedIndexChanged(object sender, EventArgs e)
    {
        string serv = VenueList.SelectedItem.Text;
        List<FanLoginService.Venue> venues = fan.GetVenues(serv).ToList();
        VenueGrid.DataSource = venues;
        VenueGrid.DataBind();
    }
}