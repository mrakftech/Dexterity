using System.Net.Http.Json;
using System.Text.Json;
using ClickATell.Constants;
using ClickATell.Requests;
using ClickATell.Response;

namespace ClickATell.Services;

public class SmsEndpoints(IHttpClientFactory clientFactory)
{
    public async Task<Root> SendMessage(SmsRequest request)
    {
       
        var client = clientFactory.CreateClient("clickATellApi");
        using var res = await client.PostAsJsonAsync(Base.SendSms, request);
        using var content = res.Content;
        var json = await content.ReadAsStringAsync();
        var data = JsonSerializer.Deserialize<Root>(json);
        return data;
    }
}