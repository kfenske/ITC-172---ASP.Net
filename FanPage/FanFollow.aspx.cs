using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FanFollow : System.Web.UI.Page
{
    FanLoginService.FanLoginServiceClient fan = new FanLoginService.FanLoginServiceClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["id"] == null)
        {
            Response.Redirect("Default.aspx");
        }

        ShowArtists();
        ShowGenres();

        if (!IsPostBack)
        {
            FillArtistList();
            FillGenreList();
        }
    }

    private void ShowArtists()
    {
        int key = (int)Session["id"];
        List<FanLoginService.Artist> artist = fan.GetFollowedArtist(key).ToList();
        DataList1.DataSource = artist;
        DataList1.DataBind();
    }

    private void ShowGenres()
    {
        int key = (int)Session["id"];
        List<FanLoginService.Genre> genre = fan.GetFollowedGenre(key).ToList();
        DataList2.DataSource = genre;
        DataList2.DataBind();
    }

    private void FillArtistList()
    {
        List<FanLoginService.Artist> artistList = fan.GetArtist().ToList();
        FollowArtistList.DataSource = artistList;
        FollowArtistList.DataTextField = "ArtistName";
        FollowArtistList.DataValueField = "ArtistKey";
        FollowArtistList.DataBind();
        ListItem item = new ListItem("");
        FollowArtistList.Items.Insert(0, item);
    }

    private void FillGenreList()
    {
        List<FanLoginService.Genre> genreList = fan.GetGenre().ToList();
        FollowGenreList.DataSource = genreList;
        FollowGenreList.DataTextField = "GenreName";
        FollowGenreList.DataValueField = "GenreKey";
        FollowGenreList.DataBind();
        ListItem item = new ListItem("");
        FollowGenreList.Items.Insert(0, item);
    }
    protected void btnFollowArtist_Click(object sender, EventArgs e)
    {
        int artistKey = int.Parse(FollowArtistList.SelectedValue);
        int fanId = (int)Session["id"];

        fan.FollowArtist(artistKey, fanId);
        lblArtist.Text = "Artist followed.";
    }
    protected void btnFollowGenre_Click(object sender, EventArgs e)
    {
        int genreKey = int.Parse(FollowGenreList.SelectedValue);
        int fanId = (int)Session["id"];

        fan.FollowGenre(genreKey, fanId);
        lblGenre.Text = "Genre followed.";
    }
}