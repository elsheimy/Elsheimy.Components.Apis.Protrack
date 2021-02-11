using System.Collections.Generic;

namespace Elsheimy.Components.Apis.Protrack.Request
{
  public abstract class ProtrackRequest
  {
    /// <summary>
    /// Path to function.
    /// </summary>
    public abstract string BaseUri { get; }
    /// <summary>
    /// This is used by all functions except 'authorization'.
    /// </summary>
    public string AccessToken { get; set; }

    /// <summary>
    /// Returns the list of request parameters packaged in a dictionary. Where Key is parameter name and Value is parameter value.
    /// </summary>
    public virtual IDictionary<string, object> GetParams()
    {
      var list = new Dictionary<string, object>();
      if (AccessToken != null) // adding access token only if necessary
        list.Add("access_token", AccessToken);
      return list;
    }

    /// <summary>
    /// Returns the list of request parameters as a query string.
    /// </summary>
    public virtual string GetParamsQueryString()
    {
      string queryString = string.Empty;

      foreach (var itm in GetParams())
      {
        // This will keep empty parameters. You can skip them if you like.
        string valueStr = string.Empty;

        if (itm.Value != null)
          valueStr = System.Uri.EscapeDataString(itm.Value.ToString());

        queryString += string.Format("{0}={1}&", itm.Key, valueStr);
      }

      return queryString;
    }

    /// <summary>
    /// Returns full request signature (request URI along with parameter query string.)
    /// </summary>
    public virtual string GetRequestUri()
    {
      return BaseUri + "?" + GetParamsQueryString();
    }

    public override string ToString()
    {
      return GetRequestUri();
    }
  }
}