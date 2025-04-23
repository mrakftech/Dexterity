using System.Net.Http.Headers;
using System.Text.Json;
using IdentityModel.Client;
using Shared.Wrapper;

namespace ICDAPI;

public class HealthCodeService(HttpClient client)
{
    private string ClientId { get; set; } = "601f7164-f577-48ef-9c17-38adc717cdad_4c7f5910-daac-46ad-a294-6f71d27a67b4";
    private string ClientSecret { get; set; } = "3I7y4UgF8d/8MQl8vpPW7ldAHkTpH32tPgW70SXuAsM=";

    public async Task<IResult<List<HealthCodeResponse>>> GetHealthCodes(string searchTerm)
    {
        //Instead of the following two lines you could directly use the token endpoint as https://icdaccessmanagement.who.int/connect/token
        var disco = await client.GetDiscoveryDocumentAsync("https://icdaccessmanagement.who.int");
        if (disco.IsError) throw new Exception(disco.Error);


        var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
        {
            Address = disco.TokenEndpoint,
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            Scope = "icdapi_access",
            GrantType = "client_credentials",
            ClientCredentialStyle = ClientCredentialStyle.AuthorizationHeader
        });

        if (tokenResponse.IsError)
        {
            return await Result<List<HealthCodeResponse>>.FailAsync(tokenResponse.Error);
        }

        client.SetBearerToken(tokenResponse.AccessToken);
        var request = new HttpRequestMessage(HttpMethod.Get,
            "https://id.who.int/icd/release/11/2021-05/mms/search?q=" + searchTerm);

        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        request.Headers.AcceptLanguage.Add(new StringWithQualityHeaderValue("en"));
        request.Headers.Add("API-Version", "v2");
        var response = await client.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine(response.StatusCode);
            return await Result<List<HealthCodeResponse>>.FailAsync(response.ReasonPhrase);
        }

        var json = response.Content.ReadAsStringAsync().Result;
        var rawData = JsonSerializer.Deserialize<List<HealthCodeResponse>>(json);
        var selectedData = rawData.Select(x => new HealthCodeResponse
        {
            Id = x.Id,
            Title = x.Title,
            TheCode = x.TheCode
        }).ToList();
        return await Result<List<HealthCodeResponse>>.SuccessAsync(selectedData);
    }
}