using Elsheimy.Components.Apis.Protrack.Helpers;
using System;
using System.Collections.Generic;

namespace Elsheimy.Components.Apis.Protrack.Request
{

  public class ProtrackAuthorizationRequest : ProtrackRequest
  {
    /// <summary>
    /// Path to function.
    /// </summary>
    public override string BaseUri { get { return "api/authorization"; } }
    public string Account { get; protected set; }
    protected string Password { get; set; }
    public DateTime RequestTimeUtc { get; private set; }

    public ProtrackAuthorizationRequest() { }
    public ProtrackAuthorizationRequest(string account, string password)
    {
      this.Account = account;
      this.Password = password;
    }

    public override IDictionary<string, object> GetParams()
    {
      RequestTimeUtc = DateTime.UtcNow;
      var unixTime = UnixTimeHelper.ToUnixTime(RequestTimeUtc);

      string signature = GetSignature(unixTime);

      var list = base.GetParams(); // retrieving base parameters (if any)
      list.Add("time", unixTime);
      list.Add("account", this.Account);
      list.Add("signature", signature);

      return list;
    }

    private string GetSignature(long unixTime)
    {
      // signature is md5(md5(password) + time) encoded as a 32 bytes lower-case characters.
      var signature = ProtrackHelper.HashMD5(this.Password);
      signature = ProtrackHelper.HashMD5(signature + unixTime.ToString());
      return signature;
    }
  }

}