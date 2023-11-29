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
    // GET CurrentTimeEntry
    public Task<TimeEntry> GetCurrentTimeEntry()
        => GenericRequest<TimeEntry>(HttpMethod.Get, "https://api.track.toggl.com/api/v9/me/time_entries/current");

    // GET TimeEntries
    public Task<TimeEntry[]> GetTimeEntries()
        => GenericRequest<TimeEntry[]>(HttpMethod.Get, "https://api.track.toggl.com/api/v9/me/time_entries");
    public Task<TimeEntry[]> GetTimeEntries(DateTime startDate, DateTime endDate)
    {
        var queryParams = new NameValueCollection
        {
            { "start_date", XmlConvert.ToString(startDate, XmlDateTimeSerializationMode.Local) },
            { "end_date", XmlConvert.ToString(endDate, XmlDateTimeSerializationMode.Local) }
        };

        return GenericRequest<TimeEntry[]>(HttpMethod.Get, "https://api.track.toggl.com/api/v9/me/time_entries", queryParams);
    }

    // POST TimeEntries
    public Task<TimeEntry> PostTimeEntry(long workspaceId, CreatingTimeEntry timeEntry)
        => GenericRequest<TimeEntry, CreatingTimeEntry>(HttpMethod.Post, $"https://api.track.toggl.com/api/v9/workspaces/{workspaceId}/time_entries", timeEntry);
}
