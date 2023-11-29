using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TogglTrackSdk.Client.AuthConfiguration;
using TogglTrackSdk.Model;
using ToggSdk.Exceptions;
using ToggSdk.Logging;

namespace TogglTrackSdk.Client;

public partial class TogglTrackClient
{
    // GET Me
    public Task<User> GetMe(bool withRelatedData)
        => GenericRequest<User>(HttpMethod.Get, "https://api.track.toggl.com/api/v9/me");

}
