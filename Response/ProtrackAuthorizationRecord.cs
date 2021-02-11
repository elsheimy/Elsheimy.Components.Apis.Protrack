using Newtonsoft.Json;

namespace Elsheimy.Components.Apis.Protrack.Response
{

  public class ProtrackAuthorizationRecord
  {
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }
    [JsonProperty("expires_in")]
    public int ExpiresInSeconds { get; set; }
  }
}


