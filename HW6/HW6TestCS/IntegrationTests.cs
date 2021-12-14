using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

using Xunit;
using static HW6;

namespace HW6TestCS
{
    public class WebFactory : WebApplicationFactory<Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
            => Host
                .CreateDefaultBuilder()
                .ConfigureWebHostDefaults(a => a
                    .UseStartup<Startup>()
                    .UseTestServer());
    }
    
    public class IntegrationTests : IClassFixture<WebFactory>
    {
        private static HttpClient _client;
        public IntegrationTests(WebFactory fixture)
        {
            _client = fixture.CreateClient();
        }
        
        private static async Task RunTest(string v1, string op, string v2, string expected)
        {
            var response = await _client.GetAsync($"/calculate?v1={v1}&op={op}&v2={v2}");
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData("7", "plus", "7", "14.0")]
        [InlineData("44", "minus", "2.5", "41.5")]
        [InlineData("8", "divide", "4", "2.0")]
        [InlineData("2", "multiply", "1.1", "2.2")]
        public async Task TestCalculate_Correct(string v1, string op, string v2, string expected)
        {
            await RunTest(v1, op, v2, expected);
        }

        [Theory]
        [InlineData("2", "n", "55", "\"The calculator does not recognize this operation: n\"")]
        [InlineData("nop", "plus", "76", "\"Wrong format of argument: nop\"")]
        [InlineData("4", "divide", "0", "\"Divide by zero(0)\"")]
        public async Task Test_Errors(string v1, string op, string v2, string expected)
        {
            await RunTest(v1, op, v2, expected);
        }
    }
}