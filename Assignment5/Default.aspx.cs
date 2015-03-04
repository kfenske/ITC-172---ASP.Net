using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        VenueLoginService.VenueLoginServiceClient vs = new VenueLoginService.VenueLoginServiceClient();
        int id = vs.Login(txtUsername.Text, txtPassword.Text);
        if (id != 0)
        {
            Session["id"] = id;
            Response.Redirect("NewShow.aspx");
        }
        else
        {
            lblMessage.Text = "Invalid Login";
        }
    }
}