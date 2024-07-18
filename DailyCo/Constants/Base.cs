namespace DailyCo.Constants;

public static class Base
{
    public static string ApiKey { get; set; } = "8cc0da37e03bb9749d11167adaab14f55f950889706bb4ad28aad684d1da1e45";
    private static string Url { get; set; } = "https://api.daily.co/v1";


    #region Rooms

    public static string CreateRoom { get; set; } = $"{Url}/rooms";

    public static string DeleteRoom(string name)
    {
        return $"https://api.daily.co/v1/rooms/{name}";
    }
    #endregion
}