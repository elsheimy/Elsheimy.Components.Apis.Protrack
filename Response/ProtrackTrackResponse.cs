using Newtonsoft.Json;

namespace Elsheimy.Components.Apis.Protrack.Response
{
  public class ProtrackTrackResponse : ProtrackResponse
  {
    [JsonProperty("record")]
    public ProtrackTrackRecord[] Records { get; set; }
  }


}


