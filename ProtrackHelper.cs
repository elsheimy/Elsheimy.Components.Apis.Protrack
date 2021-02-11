using System;

namespace Elsheimy.Components.Apis.Protrack
{
  static class ProtrackHelper
  {
    public static string HashMD5(string input)
    {
      byte[] data = System.Text.Encoding.UTF8.GetBytes(input);
      data = System.Security.Cryptography.MD5.Create().ComputeHash(data);
      return BitConverter.ToString(data).Replace("-", "").ToLower();
    }
  }
}