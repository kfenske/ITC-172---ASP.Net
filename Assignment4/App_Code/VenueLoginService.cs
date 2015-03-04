using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "VenueLoginService" in code, svc and config file together.
public class VenueLoginService : IVenueLoginService
{
    ShowTrackerEntities db = new ShowTrackerEntities();

    public bool RegisterVenue(Venue v, VenueLogin vl)
    {
        bool result = true;
        try
        {
            PasswordHash ph = new PasswordHash();
            KeyCode kc = new KeyCode();
            int code = kc.GetKeyCode();
            byte[] hashed = ph.HashIt(vl.VenueLoginPasswordPlain, code.ToString());

            Venue ven = new Venue();
            ven.VenueName = v.VenueName;
            ven.VenueEmail = v.VenueEmail;
            ven.VenueAddress = v.VenueAddress;
            ven.VenueCity = v.VenueCity;
            ven.VenueState = v.VenueState;
            ven.VenueZipCode = v.VenueZipCode;
            ven.VenuePhone = v.VenuePhone;

            VenueLogin vlog = new VenueLogin();
            vlog.VenueLoginUserName = vl.VenueLoginUserName;
            vlog.VenueLoginPasswordPlain = vl.VenueLoginPasswordPlain;
            vlog.VenueLoginRandom = code;
            vlog.VenueLoginHashed = hashed;
            vlog.VenueLoginDateAdded = DateTime.Now;
            vlog.VenueKey = ven.VenueKey;
            db.Venues.Add(ven);
            db.VenueLogins.Add(vlog);
            db.SaveChanges();
        }
        catch
        {
            result = false;
        }

        return result;
    }

    public int Login(string userName, string password)
    {
        int id = 0;

        LoginClass lc = new LoginClass(password, userName);
        id = lc.ValidateLogin();

        return id;
    }
}
