using System;
using System.Threading.Tasks;
using TogglTrackSdk.Client.AuthConfiguration;
using TogglTrackSdk.Client.TimeEntry;

namespace ToggSdk.ManualTest
{
    internal static class Program
    {

        private static async Task Main(string[] args)
        {
            var apiToken = "YOUR API KEY HERE";
            var client = new TimeEntryClient(new ApiTokenClientConfiguration(apiToken));


            var res = await client.GetCurrentTimeEntry();

            Console.WriteLine("result:");
            Console.WriteLine(res);
        }
    }
}
