using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    ShowTrackerEntities db = new ShowTrackerEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var artists = from a in db.Artists
                          orderby a.ArtistName
                          select new { a.ArtistName, a.ArtistKey };

            DropDownList1.DataSource = artists.ToList();
            DropDownList1.DataTextField = "ArtistName";
            DropDownList1.DataValueField = "ArtistKey";
            DropDownList1.DataBind();
        }
    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int key = int.Parse(DropDownList1.SelectedValue.ToString());

        var shows = from s in db.Shows
                    from d in s.ShowDetails
                    where d.ArtistKey == key
                    select new { s.ShowDate, s.ShowName, s.ShowTime };

        GridView1.DataSource = shows.ToList();
        GridView1.DataBind();
    }
}