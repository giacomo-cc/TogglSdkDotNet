using System;
using System.Text;

namespace TogglTrackSdk.Client.AuthConfiguration;

public class UsernamePasswordClientConfiguration : IClientConfiguration
{
    private readonly string username;
    private readonly string password;

    public UsernamePasswordClientConfiguration(string username, string password)
    {
        this.username = username;
        this.password = password;
    }

    public string GetAuthorizationToken()
        => $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"))}";
}
