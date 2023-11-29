using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TogglTrackSdk.Client;
using TogglTrackSdk.Client.AuthConfiguration;
using TogglTrackSdk.Model;

namespace ToggSdk.ManualTest
{
    internal static class Program
    {

        private static async Task Main(string[] args)
        {

            // right click on the project TogglTrackSdk.ManualTest and click "Manage User Secrets"
            // create a secret json like the following:
            // {
            //      "apiToken": "YOUR_API_KEY"
            // }

            var config = new ConfigurationBuilder().AddUserSecrets<UserSecretsPoco>().Build();
            var secretProvider = config.Providers.First();
            secretProvider.TryGet("apiToken", out var apiToken);

            // 

            var timeEntryClient = new TogglTrackClient(new ApiTokenClientConfiguration(apiToken));
            var me = await timeEntryClient.GetMe(false);

            Console.WriteLine(me.Id);
        }

        class UserSecretsPoco
        {
            public string ApiToken { get; set; }
        }
    }
}
