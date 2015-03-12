using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFanLoginService" in both code and config file together.
[ServiceContract]
public interface IFanLoginService
{
	[OperationContract]
	bool Register(Fan f, FanLogin fl);

    [OperationContract]
    int Login(string username, string password);

    [OperationContract]
    List<Artist> GetArtists(string artist);

    [OperationContract]
    List<Artist> GetArtist();

    [OperationContract]
    List<Genre> GetGenres(string genre);

    [OperationContract]
    List<Genre> GetGenre();

    [OperationContract]
    List<Venue> GetVenues(string venue);

    [OperationContract]
    List<string> GetVenue();

    [OperationContract]
    List<ShowInfo> ArtistShows(string artist);

    [OperationContract]
    void FollowArtist(int a, int fanKey);

    [OperationContract]
    List<Artist> GetFollowedArtist(int fanKey);

    [OperationContract]
    void FollowGenre(int g, int fanKey);

    [OperationContract]
    List<Genre> GetFollowedGenre(int fanKey);
}

[DataContract]
public class ShowInfo
{
    [DataMember]
    public string ShowName { get; set; }

    [DataMember]
    public string ArtistName { get; set; }

    [DataMember]
    public string VenueName { get; set; }

    [DataMember]
    public string ShowDate { get; set; }

    [DataMember]
    public string ShowTime { get; set; }

    [DataMember]
    public string ShowTicketInfo { get; set; }

    [DataMember]
    public string ShowDetailAdditional { get; set; }
}