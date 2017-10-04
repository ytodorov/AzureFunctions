using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using System.Net.Http;
using System.Collections.Generic;

namespace YordanAzureFunctions
{
    public static class TimerFunction
    {
        [FunctionName("TimerFunction")]
        public static void Run([TimerTrigger("0 */15 * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            log.Info($"Yordan C# Timer trigger function executed at: {DateTime.Now}");

            List<string> addressesToPing = new List<string>()
            {
                "http://www.download-youtube.org",
                "http://dyordanova.com",
                "https://toolsfornet.com",
                "http://www.kdobreva.com",
                "http://finxpro.com"

            };

            foreach (var address in addressesToPing)
            {
                using (HttpClient hc = new HttpClient())
                {
                    try
                    {
                        var res = hc.GetStringAsync(address).Result;
                        log.Info($"Pinged address {address} at {DateTime.Now}");
                    }
                    catch(AggregateException ex)
                    {
                        log.Error(ex.Message);
                    }
                }
            }

            
        }
    }
}
