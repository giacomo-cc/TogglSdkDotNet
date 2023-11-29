using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TogglTrackSdk.Client.AuthConfiguration;

namespace TogglTrackSdk.Client;

public class TogglTrackClient
{
    protected readonly HttpClient httpClient;

    protected readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
    {
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        },
        DateTimeZoneHandling = DateTimeZoneHandling.Utc
    };

    public TogglTrackClient(IClientConfiguration clientConfiguration)
    {
        httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", clientConfiguration.GetAuthorizationToken());
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
}
