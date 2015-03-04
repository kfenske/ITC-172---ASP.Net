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
            show.ShowDateEntered = s.ShowDateEntered;
            show.VenueKey = s.VenueKey;
            db.Shows.Add(show);

            ShowDetail showDetail = new ShowDetail();
            showDetail.Show = show;
            showDetail.ArtistKey = sd.ArtistKey;
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
            artist.ArtistKey = a.ArtistKey;
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

    public List<Artist> GetArtists()
    {
        var artList = from a in db.Artists
                      orderby a.ArtistName
                      select new { a.ArtistName, a.ArtistKey };

        List<Artist> artists = new List<Artist>();
        foreach (var art in artList)
        {
            Artist a = new Artist();
            a.ArtistName = art.ArtistName;
            a.ArtistKey = art.ArtistKey;
            artists.Add(a);
        }
        return artists;
    }

    public List<Show> GetShows()
    {
        var showList = from s in db.Shows
                       orderby s.ShowDate
                       select new { s.ShowName, s.ShowDate, s.ShowTicketInfo, s.ShowTime };

        List<Show> shows = new List<Show>();
        foreach (var sh in shows)
        {
            Show s = new Show();
            s.ShowName = sh.ShowName;
            s.ShowDate = sh.ShowDate;
            s.ShowTicketInfo = sh.ShowTicketInfo;
            s.ShowTime = s.ShowTime;
        }
        return shows;
    }
}
