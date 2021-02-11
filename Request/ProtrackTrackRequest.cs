using System.Collections.Generic;

namespace Elsheimy.Components.Apis.Protrack.Request
{

  public class ProtrackTrackRequest : ProtrackRequest
  {
    public override string BaseUri { get { return "api/track"; } }
    public string[] ImeiList { get; set; }

    public ProtrackTrackRequest()
    {

    }

    public ProtrackTrackRequest(string accessToken, string[] imeiList)
    {
      this.AccessToken = accessToken;
      this.ImeiList = imeiList;
    }

    public override IDictionary<string, object> GetParams()
    {
      var list = base.GetParams();
      list.Add("imeis", string.Join(",", ImeiList));

      return list;
    }
  }

}