namespace ClickATell.Constants;

public static class Base
{
    public const string ApiKey = "oTM5Df3aRiC0uMycmy1kcw==";
    private static string Url { get; set; } = "https://platform.clickatell.com";


    #region Sms

    public static string SendSms { get; set; } = $"{Url}/messages";

  
    #endregion
}