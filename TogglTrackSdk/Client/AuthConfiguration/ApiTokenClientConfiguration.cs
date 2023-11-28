using System;
using System.Text;

namespace TogglTrackSdk.Client.AuthConfiguration;

public class ApiTokenClientConfiguration : IClientConfiguration
{
    private readonly string apiToken;

    public ApiTokenClientConfiguration(string apiToken)
    {
        this.apiToken = apiToken;
    }

    public string GetAuthorizationToken()
        => $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{apiToken}:api_token"))}";
}
