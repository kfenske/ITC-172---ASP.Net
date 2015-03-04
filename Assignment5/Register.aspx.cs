using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        VenueLoginService.VenueLoginServiceClient vs = new VenueLoginService.VenueLoginServiceClient();

        VenueLoginService.Venue v = new VenueLoginService.Venue();
        v.VenueName = txtName.Text;
        v.VenueEmail = txtEmail.Text;
        v.VenueAddress = txtAddress.Text;
        v.VenueCity = txtCity.Text;
        v.VenueState = txtState.Text;
        v.VenueZipCode = txtZip.Text;
        v.VenuePhone = txtPhone.Text;
        v.VenueWebPage = txtWebPage.Text;

        VenueLoginService.VenueLogin vl = new VenueLoginService.VenueLogin();
        vl.VenueLoginUserName = txtUsername.Text;
        vl.VenueLoginPasswordPlain = txtConfPassword.Text;

        bool result = vs.RegisterVenue(v, vl);

        if(result)
        {
            lblMessage.Text = "You have successfully registered.";
        }
        else
        {
            lblMessage.Text = "Registration failed.";
        }
    }
}