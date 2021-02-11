using Newtonsoft.Json;

namespace Elsheimy.Components.Apis.Protrack.Response
{
  public class ProtrackResponse
  {
    [JsonProperty("code")]
    public int Code { get; set; }

    [JsonIgnore]
    public ProtrackResponseCode ResponseCode { get { return (ProtrackResponseCode)Code; } }
    [JsonProperty("message")]
    public string Message { get; set; }
  }

}


