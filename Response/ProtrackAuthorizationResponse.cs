using Newtonsoft.Json;

namespace Elsheimy.Components.Apis.Protrack.Response
{
  public class ProtrackAuthorizationResponse : ProtrackResponse
  {
    [JsonProperty("record")]
    public ProtrackAuthorizationRecord Record { get; set; }
  }

}


