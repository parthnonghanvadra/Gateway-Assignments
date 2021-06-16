using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSharp_Recap.Assignment_2
{
    public class Assignment_2
    {
        public static async Task Execute()
        {

            ReadUrlData.UrlExecution();
            await Task.Delay(2000);
            await ReadUrlData.UrlExecutionAsync();
            await Task.Delay(2000);
            await ReadUrlData.TaskParallel();
            Console.WriteLine("\n==========================================");
            Console.WriteLine(Environment.NewLine + " Process Completed " + Environment.NewLine);

        }
    }
    public class ReadUrlData
    {
        static HttpClient client = new HttpClient();

        static readonly IEnumerable<string> urlList = new string[]
        {
            
            "https://docs.microsoft.com/education",
            "https://docs.microsoft.com/enterprise-mobility-security",
            "https://docs.microsoft.com/gaming",
            "https://docs.microsoft.com/graph",
            "https://docs.microsoft.com/microsoft-365",
            "https://docs.microsoft.com/office",
            
        };

        public static void UrlExecution()
        {
            Console.WriteLine("====================  URL fetched synchronously ====================");
            var stopwatch = Stopwatch.StartNew();

            foreach (var url in urlList)
            {
                 ProcessUrl(url);
            }
            stopwatch.Stop();

            Console.WriteLine($"\nElapsed time: {stopwatch.Elapsed}\n");
        }

        public static async Task UrlExecutionAsync()
        {
            Console.WriteLine("==================== URL fetched using async/await ====================");
            var stopwatch = Stopwatch.StartNew();

            foreach (var url in urlList)
            {
                await ProcessUrlAsync(url);
            }

            stopwatch.Stop();
            Console.WriteLine($"\nElapsed time: {stopwatch.Elapsed}\n");
        }

        public static async Task TaskParallel()
        {
            Console.WriteLine("==================== URL fetched using Task Parallel ====================");
            var stopwatch = Stopwatch.StartNew();

            IEnumerable<Task> urlTasksQuery = from url in urlList select ProcessUrlAsync(url);
            List<Task> urlTasks = urlTasksQuery.ToList();

            await Task.WhenAll(urlTasks);
            stopwatch.Stop();

            Console.WriteLine($"\nElapsed time: {stopwatch.Elapsed}\n");
        }

        static async Task ProcessUrlAsync(string url)
        {
            byte[] content = await client.GetByteArrayAsync(url);
            Console.WriteLine(url);
        }

        static void ProcessUrl(string url)
        {
            var response = client.GetAsync(url).GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(url);
            }
        }
    }
}
