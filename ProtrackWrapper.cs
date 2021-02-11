using Elsheimy.Components.Apis.Protrack.Helpers;
using Elsheimy.Components.Apis.Protrack.Request;
using Elsheimy.Components.Apis.Protrack.Response;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace Elsheimy.Components.Apis.Protrack
{
  public class ProtrackWrapper
  {
    /// <summary>
    /// Account username
    /// </summary>
    public string Account { get; protected set; }
    /// <summary>
    /// Account password
    /// </summary>
    public string Password { get; protected set; }
    /// <summary>
    /// API base URI
    /// </summary>
    protected virtual string BaseUri { get { return "http://api.protrack365.com/api"; } }
    /// <summary>
    /// This will be used for all requests
    /// </summary>
    public string AccessToken { get; protected set; }
    /// <summary>
    /// Access token expiry date
    /// </summary>
    public DateTime? AccessTokenExpiresOnUtc { get; protected set; }


    public ProtrackWrapper(string account, string password)
    {
      this.Account = account;
      this.Password = password;
    }

    /// <summary>
    /// Returns a response from a web resource.
    /// </summary>
    /// <returns>Response represented as string.</returns>
    protected static string GetResponse(string requestUri)
    {
      HttpWebRequest req = WebRequest.CreateHttp(requestUri);
      using (var rsp = req.GetResponse())
      using (var stm = rsp.GetResponseStream())
      using (var rdr = new StreamReader(stm))
      {
        return rdr.ReadToEnd();
      }
    }

    protected virtual T GetResponse<T>(ProtrackRequest req) where T : ProtrackResponse
    {
      var requestUrl = new Uri(new Uri(BaseUri), req.GetRequestUri()).ToString();

      var rspStr = GetResponse(requestUrl);

      T rsp = JsonConvert.DeserializeObject<T>(rspStr, new JsonUnixTimeConverter());
      // should not throw a generic exception, 
      // and should not throw an exception for everything
      // we will just keep it for now
      if (rsp.Code != 0)
        throw new Exception(rsp.Message);

      return rsp;
    }


    public void Authorize()
    {
      this.AccessToken = null;
      this.AccessTokenExpiresOnUtc = null;

      var req = new ProtrackAuthorizationRequest(this.Account, this.Password);
      var rsp = GetResponse<ProtrackAuthorizationResponse>(req);

      // updating access token and expiration time
      this.AccessToken = rsp.Record.AccessToken;
      this.AccessTokenExpiresOnUtc = req.RequestTimeUtc.AddSeconds(rsp.Record.ExpiresInSeconds);
    }

    public ProtrackTrackRecord Track(string imei)
    {
      return Track(new string[] { imei })[0];
    }
    public ProtrackTrackRecord[] Track(string[] imeiList)
    {
      if (this.AccessToken == null || DateTime.UtcNow >= this.AccessTokenExpiresOnUtc)
      {
        Authorize();
      }

      var req = new ProtrackTrackRequest(this.AccessToken, imeiList);
      var rsp = GetResponse<ProtrackTrackResponse>(req);

      return rsp.Records;
    }

    public ProtrackPlaybackRecord[] Playback(string imei, DateTime beginTimeUtc, DateTime endTimeUtc)
    {
      if (this.AccessToken == null || DateTime.UtcNow >= this.AccessTokenExpiresOnUtc)
      {
        Authorize();
      }

      var req = new ProtrackPlaybackRequest(this.AccessToken, imei, beginTimeUtc, endTimeUtc);
      var rsp = GetResponse<ProtrackPlaybackResponse>(req);

      return rsp.GetRecords();
    }

  }
}