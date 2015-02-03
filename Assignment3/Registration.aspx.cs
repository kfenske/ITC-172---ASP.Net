using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        ShowTrackerEntities db = new ShowTrackerEntities();
        KeyCode k = new KeyCode();
        int seed = k.GetKeyCode();
        PasswordHash phash = new PasswordHash();

        try
        {
            byte[] pass = phash.HashIt(txtConfirm.Text, seed.ToString());

            Fan f = new Fan();
            f.FanName = txtName.Text;
            f.FanEmail = txtEmail.Text;
            db.Fans.Add(f);
            db.SaveChanges();

            //Select FanKey in order to tie two tables together
            var fanKey = (from ff in db.Fans
                          where ff.FanName == txtName.Text
                          select ff.FanKey).First();
            
            FanLogin fl = new FanLogin();
            fl.FanLoginUserName = txtUserName.Text;
            fl.FanLoginRandom = seed;
            fl.FanLoginPasswordPlain = txtConfirm.Text;
            fl.FanLoginHashed = pass;
            fl.FanLoginDateAdded = DateTime.Now;
            fl.FanKey = Convert.ToInt32(fanKey);

            db.FanLogins.Add(fl);
            db.SaveChanges();
            lblErrorSuccess.Text = "You were successfully registered.";
        }
        catch (Exception ex)
        {
            lblErrorSuccess.Text = ex.Message;
        }
    }
}