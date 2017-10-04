using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using System.Net.Http;

namespace YordanAzureFunctions
{
    public static class TimerFunction
    {
        [FunctionName("TimerFunction")]
        public static void Run([TimerTrigger("0 */15 * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            log.Info($"Yordan C# Timer trigger function executed at: {DateTime.Now}");


            using (HttpClient hc = new HttpClient())
            {
                var res = hc.GetStringAsync("http://dyordanova.com").Result;
            }
        }
    }
}
