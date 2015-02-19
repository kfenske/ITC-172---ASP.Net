using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AddShowService" in code, svc and config file together.
public class AddShowService : IAddShowService
{
    ShowTrackerEntities db = new ShowTrackerEntities();

	public bool addShow(Show s, ShowDetail sd)
    {
        bool result = true;
        try
        {
            Show show = new Show();
            show.ShowName = s.ShowName;
            show.ShowTime = s.ShowTime;
            show.ShowDate = s.ShowDate;
            show.ShowTicketInfo = s.ShowTicketInfo;
            db.Shows.Add(show);

            ShowDetail showDetail = new ShowDetail();
            showDetail.Show = show;
            showDetail.Artist = sd.Artist;
            showDetail.ShowDetailArtistStartTime = sd.ShowDetailArtistStartTime;
            showDetail.ShowDetailAdditional = sd.ShowDetailAdditional;
            db.ShowDetails.Add(showDetail);
            db.SaveChanges();
        }
        catch
        {
            result = false;
        }

        return result;
    }

    public bool addArtist(Artist a)
    {
        bool result = true;
        try
        {
            Artist artist = new Artist();
            artist.ArtistName = a.ArtistName;
            artist.ArtistEmail = a.ArtistEmail;
            artist.ArtistWebPage = a.ArtistWebPage;
            db.Artists.Add(artist);
            db.SaveChanges();
        }
        catch
        {
            result = false;
        }

        return result;
    }
}
