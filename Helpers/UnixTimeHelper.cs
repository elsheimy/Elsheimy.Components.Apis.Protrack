using System;

namespace Elsheimy.Components.Apis.Protrack.Helpers
{
  static class UnixTimeHelper
  {
    /// <summary>
    /// Converts DateTime to Unix time.
    /// </summary>
    public static long ToUnixTime(this DateTime time)
    {
      var totalSeconds = (long)(time.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;


      return totalSeconds;
    }
    /// <summary>
    /// Converts Unix time to DateTime.
    /// </summary>
    public static DateTime ToDateTime(long unixTime)
    {
      return new DateTime(1970, 1, 1).Add(TimeSpan.FromSeconds(unixTime));
    }
  }
}