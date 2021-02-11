namespace Elsheimy.Components.Apis.Protrack.Response
{
  public enum ProtrackResponseCode
  {
    Success = 0,
    SystemError = 10000,
    UnknownRequest = 10001,
    LoginTimeout = 10002,
    Unauthorized = 10003,
    ParameterError = 10004,
    MissingParameter = 10005,
    ParamOutOfRange = 10006,
    PermissionDenied = 10007,
    RequestLimit = 10009,
    AccessTokenNotExist = 10010,
    AccessTokenInvalid = 10011,
    AccessTokenExpired = 10012,
    ImeiUnauthorized = 10013,
    RequestTimeError = 10014,
    LoginFailed = 20001,
    TargetNotExist = 20005,
    DeviceOffline = 20017,
    SendCommandFailed = 20018,
    NoData = 20023,
    TargetExpired = 20046,
    Unsupported = 20048
  }
}


