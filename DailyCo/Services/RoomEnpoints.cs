using System.Net.Http.Json;
using System.Text.Json;
using DailyCo.Constants;
using DailyCo.Requests;
using DailyCo.Responses.Room;

namespace DailyCo.Services;

public class RoomEnpoints(IHttpClientFactory clientFactory)
{
    public async Task<RoomResponse> CreateMeetingLink(string name)
    {
        var request = new CreateRoomRequest()
        {
            Name = name,
            Privacy = "public"
        };
        var client = clientFactory.CreateClient("dailyCoApi");
        using var res = await client.PostAsJsonAsync(Base.CreateRoom, request);
        using var content = res.Content;
        var json = await content.ReadAsStringAsync();
        var data = JsonSerializer.Deserialize<RoomResponse>(json);
        return data;
    }

    public async Task<string> DeleteRoom(string name)
    {
        var client = clientFactory.CreateClient("dailyCoApi");
        using var res = await client.DeleteAsync(Base.DeleteRoom(name));
        if (res.IsSuccessStatusCode)
        {
            return "Room has been deleted.";
        }

        return "";
    }
}