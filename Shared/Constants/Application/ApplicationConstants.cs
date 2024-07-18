namespace Shared.Constants.Application;

public static class ApplicationConstants
{
    public const string DefaultPassword = "Dexterity123@";


    public static List<string> GetPasswordResetDuration()
    {
        List<string> durations =
        [
            "Every 30 Days",
            "Every 60 Days",
            "Every 90 Days",
            "Every 6 Months",
            "Every 1 Year",
            "Every 5 Years"
        ];
        return durations;
    }
}