using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FanLoginService" in code, svc and config file together.
public class FanLoginService : IFanLoginService
{
    ShowTrackerEntities showDb = new ShowTrackerEntities();

	public bool Register(Fan f, FanLogin fl)
	{
        bool result = true;
        try
        {
             PasswordHash phash = new PasswordHash();
             KeyCode kCode = new KeyCode();
             int key = kCode.GetKeyCode();
             byte[] hash = phash.HashIt(fl.FanLoginPasswordPlain, key.ToString());

             Fan fan = new Fan();
             fan.FanName = f.FanName;
             fan.FanEmail = f.FanEmail;
             fan.FanDateEntered = DateTime.Now;
             showDb.Fans.Add(fan);

             FanLogin fanLog = new FanLogin();
             fanLog.Fan = fan;
             fanLog.FanLoginUserName = fl.FanLoginUserName;
             fanLog.FanLoginPasswordPlain = fl.FanLoginPasswordPlain;
             fanLog.FanLoginRandom = key;
             fanLog.FanLoginHashed = hash;
             fanLog.FanLoginDateAdded = DateTime.Now;
             showDb.FanLogins.Add(fanLog);
             showDb.SaveChanges();
        }
        catch
        {
            result = false;
        }

        return result;
	}

    public int Login(string username, string password)
    {
        LoginClass login = new LoginClass(username, password);
        int key = login.ValidateLogin();
        return key;
    }

    public List<Artist> GetArtists(string genre)
    {
        var artList = from a in showDb.Artists
                      from g in a.Genres
                      orderby a.ArtistName
                      where g.GenreName.Equals(genre)
                      select new { a.ArtistName, a.ArtistKey, a.ArtistWebPage, g.GenreName };

        List<Artist> artists = new List<Artist>();
        foreach (var art in artList)
        {
            Artist a = new Artist();
            a.ArtistName = art.ArtistName;
            a.ArtistWebPage = art.ArtistWebPage;
            artists.Add(a);
        }
        return artists;
    }

    public List<Artist> GetArtist()
    {
        var artList = from a in showDb.Artists
                      orderby a.ArtistName
                      select new { a.ArtistName, a.ArtistKey };

        List<Artist> servList = new List<Artist>();
        foreach (var v in artList)
        {
            Artist art = new Artist();
            art.ArtistName = v.ArtistName;
            art.ArtistKey = v.ArtistKey;
            servList.Add(art);
        }
        return servList;
    }

    public List<Genre> GetGenres(string genre)
    {
        var genList = from g in showDb.Genres
                      orderby g.GenreName
                      where g.GenreName.Equals(genre)
                      select new { g.GenreName, g.GenreKey };

        List<Genre> genres = new List<Genre>();
        foreach (var gen in genList)
        {
            Genre g = new Genre();
            g.GenreName = gen.GenreName;
            g.GenreKey = gen.GenreKey;
            genres.Add(g);
        }
        return genres;
    }

    public List<Genre> GetGenre()
    {
        var genList = from g in showDb.Genres
                      orderby g.GenreName
                      select new { g.GenreName, g.GenreKey };

        List<Genre> servList = new List<Genre>();
        foreach (var v in genList)
        {
            Genre gen = new Genre();
            gen.GenreKey = v.GenreKey;
            gen.GenreName = v.GenreName;
            servList.Add(gen);
        }
        return servList;
    }

    public List<Venue> GetVenues(string venue)
    {
        var venList = from v in showDb.Venues
                      orderby v.VenueName
                      where v.VenueName.Equals(venue)
                      select new { v.VenueName, v.VenueAddress, v.VenueCity, v.VenueState, v.VenueZipCode, v.VenuePhone, v.VenueWebPage };

        List<Venue> venues = new List<Venue>();
        foreach (var ven in venList)
        {
            Venue v = new Venue();
            v.VenueName = ven.VenueName;
            v.VenueAddress = ven.VenueAddress;
            v.VenueCity = ven.VenueCity;
            v.VenueState = ven.VenueState;
            v.VenueZipCode = ven.VenueZipCode;
            v.VenuePhone = ven.VenuePhone;
            v.VenueWebPage = ven.VenueWebPage;
            venues.Add(v);
        }
        return venues;
    }

    public List<string> GetVenue()
    {
        var venList = from v in showDb.Venues
                      orderby v.VenueName
                      select new { v.VenueName };

        List<string> servList = new List<string>();
        foreach (var a in venList)
        {
            servList.Add(a.VenueName);
        }
        return servList;
    }

    public List<ShowInfo> ArtistShows(string artist)
    {
        var showList = from s in showDb.Shows
                       from sd in s.ShowDetails
                       orderby s.ShowName
                       where sd.Artist.ArtistName == artist
                       select new { s.ShowName, s.ShowDate, s.ShowTime, s.ShowTicketInfo, sd.ShowDetailAdditional, sd.Artist.ArtistName, s.Venue.VenueName };

        List<ShowInfo> shows = new List<ShowInfo>();
        foreach (var x in showList)
        {
            ShowInfo s = new ShowInfo();
            s.ShowName = x.ShowName;
            s.ArtistName = x.ArtistName;
            s.VenueName = x.VenueName;
            s.ShowDate = x.ShowDate.ToString();
            s.ShowTime = x.ShowTime.ToString();
            s.ShowTicketInfo = x.ShowTicketInfo;
            s.ShowDetailAdditional = x.ShowDetailAdditional;
            shows.Add(s);
        }
        return shows;
    }

    public void FollowArtist(int artistKey, int fanKey)
    {
        Artist art = showDb.Artists.FirstOrDefault(o => o.ArtistKey == artistKey);

        Fan f2 = (from f in showDb.Fans where f.FanKey == fanKey select f).FirstOrDefault();

        f2.Artists.Add(art);
        showDb.SaveChanges();
    }

    public List<Artist> GetFollowedArtist(int fanKey)
    {
        var fan = from f in showDb.Fans
                  from a in f.Artists
                  where f.FanKey == fanKey
                  select new { a.ArtistName, a.ArtistWebPage };

        List<Artist> artist = new List<Artist>();
        foreach (var v in fan)
        {
            Artist art = new Artist();
            art.ArtistName = v.ArtistName;
            art.ArtistWebPage = v.ArtistWebPage;
            artist.Add(art);
        }
        return artist;
    }

    public void FollowGenre(int genreKey, int fanKey)
    {
        Genre gen = showDb.Genres.FirstOrDefault(o => o.GenreKey == genreKey);

        Fan f2 = (from f in showDb.Fans where f.FanKey == fanKey select f).FirstOrDefault();

        f2.Genres.Add(gen);
        showDb.SaveChanges();
    }

    public List<Genre> GetFollowedGenre(int fanKey)
    {
        var fan = from f in showDb.Fans
                  from g in f.Genres
                  where f.FanKey == fanKey
                  select new { g.GenreName, g.GenreDescription };

        List<Genre> genre = new List<Genre>();
        foreach (var v in fan)
        {
            Genre gen = new Genre();
            gen.GenreName = v.GenreName;
            gen.GenreDescription = v.GenreDescription;
            genre.Add(gen);
        }
        return genre;
    }
}
