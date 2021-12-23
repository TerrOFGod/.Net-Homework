using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HW11;
using HW11.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Xunit;

namespace HW11IntegrationTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault
                    (d => d.ServiceType == typeof(DbContextOptions<ApplicationContext>));

                if (descriptor != null)
                    services.Remove(descriptor);

                // Add ApplicationDbContext using an in-memory database for testing.
                services.AddDbContext<ApplicationContext>
                    ((_, context) => context.UseInMemoryDatabase("DbForTests"));

                // Build the service provider.
                var serviceProvider = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database
                // context (ApplicationDbContext).
                using var scope = serviceProvider.CreateScope();

                var db = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                var logger = scope.ServiceProvider.GetRequiredService
                    <ILogger<CustomWebApplicationFactory<TStartup>>>();

                // Ensure the database is created.
                db.Database.EnsureCreated();
            });
        }
    }

    public class IntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private const string Path = "https://localhost:5001/Calculator/Calculator";
        private readonly HttpClient _client;
        private const string Error = "Wrong parameters was entered.";
        
        public IntegrationTests(CustomWebApplicationFactory<Startup> fixture)
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
        [InlineData("", "Error: User enter null or empty string")]
        [InlineData("a", "Error: Calculator does not recognize operation: a")]
        [InlineData("5 pl", Error)]
        [InlineData("(5 pl * )", Error)]
        [InlineData(")5 pl 3(", "Error: Expression can not start with right bracket")]
        [InlineData("((64 - 3) * 2", "Error: Expression have wrong balance of brackets(l more r)")]
        [InlineData("(64 - 3) * 2)", "Error: Expression have wrong balance of brackets(l less r)")]
        [InlineData("(33 pl 2) * /", Error)]
        [InlineData("* / (33 pl 2)", Error)]
        [InlineData("(2 pl 23) * ()", Error)]
        public async Task Calculate_InvalidArguments_Wrong(string expression, string exception)
        {
            await RunTests(expression, exception);
        }

        private async Task RunTests(string expression, string expected)
        {
            var content = await GetContent(expression);
            var result = GetResult(content);
            Assert.Equal(expected, result);
        }

        private async Task<string> GetContent(string expression)
        {
            var str = $"expression={expression}";
            var stringContent = new StringContent(str, Encoding.UTF8);
            stringContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
            var response = await _client.PostAsync(Path, stringContent);
            return await response.Content.ReadAsStringAsync();
        }

        private static string GetResult(string str) 
            => str.Split(@"<span id=""result"" class=""form-control"">")[1]
                .Split("</span")[0];
        
        [Theory]
        [InlineData("1 + 2 * (3 pl 4 / 2 - (1 pl 2)) * 2 pl 1")]
        private async Task Calculator_ParallelTest(string expression)
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

        private async Task<long> GetTimeAsync(string expression)
        {
            var sw = new Stopwatch();
            sw.Start();
            await GetContent(expression);
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
        
        [Theory]
        [InlineData("1 + 2 * (3 pl 4 / 2 - (1 pl 2)) * 2 pl 1 pl 3")]
        private async Task Calculator_TimeTest(string expression)
        {
            var time1 = await GetTimeAsync(expression);
            var time2 = await GetTimeAsync(expression);
            Assert.True(time2 < 1000);
        }
    }
}