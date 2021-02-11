using Elsheimy.Components.Apis.Protrack.Helpers;
using System;
using System.Collections.Generic;

namespace Elsheimy.Components.Apis.Protrack.Request
{
  public class ProtrackPlaybackRequest : ProtrackRequest
  {
    public override string BaseUri { get { return "api/playback"; } }
    public string Imei { get; set; }
    public DateTime BeginTimeUtc { get; set; }
    public DateTime EndTimeUtc { get; set; }

    public ProtrackPlaybackRequest()
    {

    }

    public ProtrackPlaybackRequest(string accessToken, string imei, DateTime beginTimeUtc, DateTime endTimeUtc)
    {
      this.AccessToken = accessToken;
      this.Imei = imei;
      this.BeginTimeUtc = beginTimeUtc;
      this.EndTimeUtc = endTimeUtc;
    }

    public override IDictionary<string, object> GetParams()
    {
      var list = base.GetParams();
      list.Add("imei", this.Imei);
      list.Add("begintime", UnixTimeHelper.ToUnixTime(BeginTimeUtc));
      list.Add("endtime", UnixTimeHelper.ToUnixTime(EndTimeUtc));

      return list;
    }
  }
}


