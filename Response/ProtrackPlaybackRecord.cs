using Elsheimy.Components.Apis.Protrack.Helpers;
using System;

namespace Elsheimy.Components.Apis.Protrack.Response
{


  public class ProtrackPlaybackRecord
  {
    public decimal Longitude { get; set; }
    public decimal Latitude { get; set; }
    public DateTime GpsTimeUtc { get; set; }
    public int Speed { get; set; }
    public int Course { get; set; }

    public ProtrackPlaybackRecord()
    {

    }
    public ProtrackPlaybackRecord(string str)
    {
      string[] args = str.Split(',');

      Longitude = decimal.Parse(args[0]);
      Latitude = decimal.Parse(args[1]);
      GpsTimeUtc = UnixTimeHelper.ToDateTime(int.Parse(args[2]));
      Speed = int.Parse(args[3]);
      Course = int.Parse(args[4]);
    }
  }
}


