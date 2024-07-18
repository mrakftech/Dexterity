using Shared.Responses.UserAccounts;

namespace Shared.State;

public static class ApplicationState
{
    public static LoginResponse CurrentUser { get; set; }
    public static bool IsLoggedIn { get; set; }
    public static string MeetingName { get; set; }
}