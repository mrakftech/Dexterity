using Shared.Helper;

namespace DailyCo.Requests;

public class CreateRoomRequest
{
    public string Name { get; set; } = CryptographyHelper.GetUniqueKey(20);
    public string Privacy { get; set; } = "public";
}