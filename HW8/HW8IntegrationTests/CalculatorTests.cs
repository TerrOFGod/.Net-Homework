using System.Net.Http;
using System.Threading.Tasks;
using HW8;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace HW8IntegrationTests
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
        private const string Path = "https://localhost:5001/Calculator/Calculate";
        private readonly HttpClient _client;
        
        public IntegrationTests(HostBuilder fixture)
        {
            _client = fixture.CreateClient();
        }

        [Theory]
        [InlineData("4", "plus", "3", "7")]
        [InlineData("32", "minus", "2", "30")]
        [InlineData("6", "division", "5", "1.2")]
        [InlineData("4", "multiplication", "2", "8")]
        public async Task Calculate_ValidArguments_Correct(string v1, string op, string v2, string excepted)
        {
            await MakeGeneralPartTests(v1, op, v2, excepted);
        }
        
        [Theory]
        [InlineData("error1", "plus", "7", "Value is not double: error1")]
        [InlineData("44", "minus", "error2", "Value is not double: error2")]
        [InlineData("error1", "minus", "error2", "Value is not double: error1 and Value is not double: error2")]
        [InlineData("64", "error", "88", "The calculator does not recognize this operation: error")]
        [InlineData("66", "division", "0", "You can't divide by zero")]
        [InlineData("0", "division", "0", "The result is undefined")]
        public async Task Calculate_InvalidArguments_Wrong(string v1, string op, string v2, string excepted)
        {
            await MakeGeneralPartTests(v1, op, v2, excepted);
        }

        private async Task MakeGeneralPartTests(string v1, string op, string v2, string excepted)
        {
            var response = await _client.GetAsync($"{Path}?v1={v1}&op={op}&v2={v2}");
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal(excepted, result);
        }
    }
}