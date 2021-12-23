using HW13;
using Xunit;
using System.Net.Http;
using Xunit.Abstractions;
using JetBrains.dotMemoryUnit;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;

namespace HW13MemoryTest
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
    
    public class MemoryTest : IClassFixture<HostBuilder>
    {
        private readonly HttpClient _client;
        private ITestOutputHelper _output;

        public MemoryTest(HostBuilder factory, ITestOutputHelper output)
        {
            _output = output;
            DotMemoryUnitTestOutput.SetOutputMethod(output.WriteLine);
            _client = factory.CreateClient();
        }
        
        [DotMemoryUnit(FailIfRunWithoutSupport = true, CollectAllocations = true)]
        [Theory]
        [MemberData(nameof(GenerateData))]
        public void CalculatorController_ReturnCorrectResult(string op)
            => MakeTest(op);

        private void MakeTest(string expression)
        {
            var memoryBefore = dotMemory.Check();

            _client
                .PostAsync("/Calculator/Calculator", new StringContent("expression=" + expression))
                .GetAwaiter()
                .GetResult();
            
            
            dotMemory.Check(memory =>
            {
                _output.WriteLine(memory.GetTrafficFrom(memoryBefore).CollectedMemory.SizeInBytes.ToString());
                Assert.True(
                    memory
                        .GetTrafficFrom(memoryBefore)
                        .Where(a => a.Type == typeof(string))
                        .AllocatedMemory.SizeInBytes < 2000000);
            });
        }

        public static IEnumerable<object[]> GenerateData()
        {
            for (var i = 0; i < 100; i++)
                yield return new object[] {i + " pl " + i};
        }
    }
}