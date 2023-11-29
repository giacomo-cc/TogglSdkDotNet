using System;

namespace TogglTrackSdk.Model;

public class User
{
    public string ApiToken { get; set; }
    public string At { get; set; }
    public long BeginningOfWeek { get; set; }
    public long CountryId { get; set; }
    public DateTime CreatedAt { get; set; }
    public long DefaultWorkspaceId { get; set; }
    public string Email { get; set; }
    public string Fullname { get; set; }
    public bool HasPassword { get; set; }
    public long Id { get; set; }
    public string ImageUrl { get; set; }
    public string IntercomHash { get; set; }
    public string[] OauthProviders { get; set; }
    public string OpenidEmail { get; set; }
    public bool OpenidEnabled { get; set; }
}
