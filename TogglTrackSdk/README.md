# TogglSdk

This sdk provides an abstraction over the latest [Toggl](https://toggl.com) API v9 as described here: https://developers.track.toggl.com/docs/.

Contributions are welcome, please submit issues or PRs.

## Development

### Api Token

In order to access TooglTrack API you have to authenticate with the API, [here](https://developers.track.toggl.com/docs/authentication) you can find an extensive documentations.

The most common way to authenticate is using an api key, you can retrieve your current apiKey from [here](https://track.toggl.com/profile). Once you have the api key you can configure the ManualTest project secrets: right click on the project TogglTrackSdk.ManualTest and click "Manage User Secrets", then create a secret json like the following:

```json
{
  "apiToken": "YOUR_API_KEY"
}
```
