using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewShow : System.Web.UI.Page
{
    AddShowService.AddShowServiceClient add = new AddShowService.AddShowServiceClient();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        if (!IsPostBack)
        {
            FillArtistList();
        }
        SetArtistInvisible();
    }
    protected void btnAddShow_Click(object sender, EventArgs e)
    {
        int key = (int)Session["id"];
        DateTime date = calDate.SelectedDate;
        AddShowService.Show show = new AddShowService.Show();

        show.ShowName = txtShowName.Text;
        show.ShowTime = TimeSpan.Parse(txtTime.Text);
        show.ShowDate = date;
        show.ShowTicketInfo = txtTicketInfo.Text;
        show.VenueKey = key;
        show.ShowDateEntered = DateTime.Now;

        AddShowService.ShowDetail showDet = new AddShowService.ShowDetail();
        showDet.ArtistKey = int.Parse(lblArtistKey.Text);
        showDet.ShowDetailArtistStartTime = TimeSpan.Parse(txtStartTime.Text);
        showDet.ShowDetailAdditional = txtDetails.Text;

        bool result = add.addShow(show, showDet);
        if(!result)
        {
            lbMessage.Text = "The show was not saved.";
        }
        else
        {
            lbMessage.Text = "Show saved successfully.";
        }
    }

    private void FillArtistList()
    {
        List<AddShowService.Artist> artists = new List<AddShowService.Artist>();
        artists = add.GetArtists().ToList();
        dlArtist.DataSource = artists;
        dlArtist.DataTextField = "ArtistName";
        dlArtist.DataValueField = "ArtistKey";
        dlArtist.DataBind();
        ListItem item = new ListItem("New Artist");
        dlArtist.Items.Add(item);
    }

    private void SetArtistInvisible()
    {
        tblArtist.Visible = false;
    }
    protected void dlArtist_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(dlArtist.SelectedItem.Text.Equals("New Artist"))
        {
            tblArtist.Visible = true;
        }
        else
        {
            lblArtistKey.Text = dlArtist.SelectedItem.Value.ToString();
        }
    }
    protected void btnAddArtist_Click(object sender, EventArgs e)
    {
        AddShowService.Artist a = new AddShowService.Artist();
        a.ArtistName = txtArtName.Text;
        a.ArtistEmail = txtArtEmail.Text;
        a.ArtistWebPage = txtArtWebPage.Text;
        bool result = add.addArtist(a);
        if (!result)
        {
            lblSaveArtist.Text = "The artist was not saved.";
        }
        else
        {
            FillArtistList();
            lblArtistKey.Text = a.ArtistKey.ToString();
            lblSaveArtist.Text = "Artist successfully saved.";
        }
    }
}