using Newtonsoft.Json;
using System.Collections.Generic;

namespace Elsheimy.Components.Apis.Protrack.Response
{
  public class ProtrackPlaybackResponse : ProtrackResponse
  {
    [JsonProperty("record")]
    public string RecordString { get; set; }

    // a custom JSON converter can be used here too
    public ProtrackPlaybackRecord[] GetRecords()
    {
      var recordsStrList = RecordString.Split(';');
      List<ProtrackPlaybackRecord> records = new List<ProtrackPlaybackRecord>(recordsStrList.Length);

      foreach (var recordStr in recordsStrList)
      {
        if (recordStr.Length == 0)
          continue;

        var record = new ProtrackPlaybackRecord(recordStr);
        records.Add(record);
      }

      return records.ToArray();
    }
  }
}


