using PhoneNumbers;
using Shared.Constants.Application;

namespace Shared.Helper;

public static class Method
{
    public static DateTime GetPasswordResetTime(string key)
    {
        DateTime dateTime = DateTime.UtcNow;
        switch (key)
        {
            case "Every 30 Days":
                dateTime = DateTime.UtcNow.AddDays(30);
                break;
            case "Every 60 Days":
                dateTime = DateTime.UtcNow.AddDays(60);
                break;
            case "Every 90 Days":
                dateTime = DateTime.UtcNow.AddDays(90);
                break;
            case "Every 6 Months":
                dateTime = DateTime.UtcNow.AddMonths(6);
                break;
            case "Every 1 Year":
                dateTime = DateTime.UtcNow.AddYears(1);
                break;
            case "Every 5 Years":
                dateTime = DateTime.UtcNow.AddYears(5);
                break;
            default:
                return dateTime;
        }

        return dateTime;
    }

    public static string GetPasswordResetIn(DateTime time)
    {
        TimeSpan dateTime = (time - DateTime.UtcNow);

        if (dateTime.TotalDays <= 30)
        {
            return "Every 30 Days";
        }

        if (dateTime.TotalDays > 30 && dateTime.TotalDays <= 60)
        {
            return "Every 60 Days";
        }

        if (dateTime.TotalDays > 60 && dateTime.TotalDays <= 90)
        {
            return "Every 90 Days";
        }

        if (dateTime.TotalDays >= 183)
        {
            return "Every 6 Months";
        }

        if (dateTime.TotalDays > 183 && dateTime.TotalDays <= 365)
        {
            return "Every 1 Year";
        }

        if (dateTime.TotalDays > 365)
        {
            return "Every 5 Years";
        }

        return "";
    }

    public static string GetMobileFormat(string mobileNumber)
    {
        var util = PhoneNumberUtil.GetInstance();
        var s = util.Parse(mobileNumber, ApplicationConstants.AppRegion);
        return util.Format(s, PhoneNumberFormat.E164);
    }

    public static string FaIcon(string icon) => $"<i class=\"fa fa-solid {icon}\"></i>";
}