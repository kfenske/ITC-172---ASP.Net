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
        FanLoginService.FanLoginServiceClient fls = new FanLoginService.FanLoginServiceClient();

        FanLoginService.Fan f = new FanLoginService.Fan();
        f.FanName = txtName.Text;
        f.FanEmail = txtEmail.Text;
        f.FanDateEntered = DateTime.Now;

        FanLoginService.FanLogin fl = new FanLoginService.FanLogin();
        fl.FanLoginUserName = txtUsername.Text;
        fl.FanLoginPasswordPlain = txtConfPassword.Text;

        bool result = fls.Register(f, fl);

        if(result)
        {
            lblMessage.Text = "You have successfully registered";
        }
        else
        {
            lblMessage.Text = "Registration failed.";
        }
    }
}