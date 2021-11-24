using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HW9;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace HW9IntegrationTests
{
    public class HostBuilder : WebApplicationFactory<Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
            => Host
                .CreateDefaultBuilder()
                .ConfigureWebHostDefaults(a => a
                    .UseStartup<Startup>()
                    .UseTestServer());
    }

    public class IntegrationTests : IClassFixture<HostBuilder>
    {
        private const string Path = "https://localhost:5001/Calculator/Calculator";
        private readonly HttpClient _client;
        private const string Error = "Wrong parameters was entered.";
        
        public IntegrationTests(HostBuilder fixture)
        {
            _client = fixture.CreateClient();
        }
        
        [Theory]
        [InlineData("6 pl 7", "13")]
        [InlineData("4 - 5", "-1")]
        [InlineData("6 * 8", "48")]
        [InlineData("6 / 3", "2")]
        [InlineData("(5 pl 5) * 2", "20")]
        [InlineData("2 * (5 pl 5)", "20")]
        [InlineData("2 pl 2 * (5 pl 5)", "22")]
        public async Task Calculate_ValidArguments_Correct(string expression, string excepted)
        {
            await RunTests(expression, excepted);
        }
        
        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("5 pl")]
        [InlineData("(5 pl * )")]
        [InlineData(")5 pl 3(")]
        [InlineData("((64 - 3) * 2")]
        [InlineData("(64 - 3) * 2)")]
        [InlineData("(33 pl 2) * /")]
        [InlineData("* / (33 pl 2)")]
        [InlineData("(2 pl 23)()")]
        public async Task Calculate_InvalidArguments_Wrong(string expression)
        {
            await RunTests(expression, Error);
        }

        private async Task RunTests(string expression, string expected)
        {
            var str = $"expression={expression}";
            var stringContent = new StringContent(str, Encoding.UTF8);
            stringContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
            using var response = await _client.PostAsync(Path, stringContent);
            var content = await response.Content.ReadAsStringAsync();
            var result = GerResult(content);
            Assert.Equal(expected, result);
        }

        private static string GerResult(string str) 
            => str.Split(@"<span id=""result"" class=""form-control"">")[1]
                .Split("</span")[0];
        
        [Theory]
        [InlineData("1 + 2 * (3 pl 4 / 2 - (1 pl 2)) * 2 pl 1")]
        private async Task CalculatorController_ParallelTest(string expression)
        {
            var watch = new Stopwatch();
            var str = $"expression={expression}";
            var stringContent = new StringContent(str, Encoding.UTF8);
            stringContent.Headers.ContentType = 
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
            watch.Start();
            using var response = await _client.PostAsync(Path, stringContent);
            watch.Stop();
            var result = watch.ElapsedMilliseconds;
            Assert.True(result - 1000 < 500);
        }
    }
}