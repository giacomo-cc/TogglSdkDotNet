using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TogglTrackSdk.Client.AuthConfiguration;
using ToggSdk.Exceptions;
using ToggSdk.Logging;

namespace TogglTrackSdk.Client.TimeEntry;

public class TimeEntryClient : TogglTrackClient
{
    public TimeEntryClient(IClientConfiguration clientConfig) : base(clientConfig)
    {
    }

    // GET TimeEntries
    public async Task<string> GetCurrentTimeEntry()
    {
        string url = "https://api.track.toggl.com/api/v9/me/time_entries/current";

        var response = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, url)).ConfigureAwait(false);
        if (response.StatusCode == (HttpStatusCode)429)
        {
            LogManager.Instance.Info("Rate limited request, pausing before retrying");
            throw new TogglApiException("Rate limited request, pausing before retrying");
        }

        if (response.IsSuccessStatusCode)
        {
            LogManager.Instance.Debug($"Request to url {url} was a success with status code {response.StatusCode}");

            //return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync().ConfigureAwait(false), _jsonSerializerSettings);
            return await response.Content.ReadAsStringAsync();
        }
        else
        {
            throw new TogglApiException($"Request to url {url} failed with status code {response.StatusCode}");
        }
    }
}
