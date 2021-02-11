using Newtonsoft.Json;
using System;

namespace Elsheimy.Components.Apis.Protrack.Response
{
  public class ProtrackTrackRecord
  {
    [JsonProperty("imei")]
    public string IMEI { get; set; }
    [JsonProperty("longitude")]
    public decimal Longitude { get; set; }
    [JsonProperty("latitude")]
    public decimal Latitude { get; set; }
    [JsonProperty("systemtime")]
    public DateTime SystemTimeUtc { get; set; }
    [JsonProperty("gpstime")]
    public DateTime GpsTimeUtc { get; set; }

    // add any field you like
  }
}


