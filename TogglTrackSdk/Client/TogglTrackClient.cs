using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TogglTrackSdk.Client.AuthConfiguration;
using TogglTrackSdk.Model;
using ToggSdk.Exceptions;
using ToggSdk.Logging;

namespace TogglTrackSdk.Client;

public partial class TogglTrackClient
{
    private readonly HttpClient _httpClient;

    private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
    {
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        },
        DateTimeZoneHandling = DateTimeZoneHandling.Utc,
        Converters =
        {
            new Newtonsoft.Json.Converters.StringEnumConverter()
        },
        NullValueHandling = NullValueHandling.Ignore
    };

    public TogglTrackClient(IClientConfiguration clientConfiguration)
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", clientConfiguration.GetAuthorizationToken());
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    private Task<T> GenericRequest<T, K>(HttpMethod method, string url, K payload, NameValueCollection queryParams = null)
    {
        var serializedPayload = JsonConvert.SerializeObject(payload, _jsonSerializerSettings);
        return GenericRequest<T>(method, url, queryParams, payload: serializedPayload);
    }

    private async Task<T> GenericRequest<T>(HttpMethod method, string url, NameValueCollection queryParams = null, string payload = null)
    {
        var uriBuilder = new UriBuilder(url);
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);
        if (queryParams != null)
        {
            foreach (var p in queryParams)
            {
                query[p.ToString()] = queryParams[p.ToString()];
            }
            uriBuilder.Query = query.ToString();
        }

        var request = new HttpRequestMessage(method, uriBuilder.ToString());
        if (payload != null)
            request.Content = new StringContent(payload);

        var response = await _httpClient.SendAsync(request);

        if (response.StatusCode == (HttpStatusCode)429)
        {
            LogManager.Instance.Info("Rate limited request, pausing before retrying");
            throw new TogglApiException("Rate limited request, pausing before retrying");
        }

        if (response.IsSuccessStatusCode)
        {
            LogManager.Instance.Debug($"Request to url {url} was a success with status code {response.StatusCode}");

            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseBody, _jsonSerializerSettings);
        }
        else
        {
            throw new TogglApiException($"Request to url {url} failed with status code {response.StatusCode}");
        }
    }
}
