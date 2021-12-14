using System.Net.Http;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace HW12
{
    [MinColumn]
    [MaxColumn]
    [StdDevColumn]
    [StdErrorColumn]
    [MedianColumn]
    public class Benchmark
    {
        
            private HttpClient _clientCSharp;
            private HttpClient _clientFSharp;
        
            private const string FSharpUrl = "/calculate";
            private const string CSharpUrl = "https://localhost:5001/Calculator/Calculate";

            [GlobalSetup]
            public void GlobalSetUp()
            {
                _clientCSharp = new CSharpHostBuilder().CreateClient();
                _clientFSharp = new FSharpHostBuilder().CreateClient();
            }

            [Benchmark(Description = "F# 7+2")]
            public async Task PlusFSharp() 
                => await _clientFSharp.GetAsync(FSharpUrl + "?v1=7&op=plus&v2=2");
        
            [Benchmark(Description = "C# 7+2")]
            public async Task PlusCSharp() 
                => await _clientCSharp.GetAsync(CSharpUrl + "?v1=7&op=plus&v2=2");
            
            [Benchmark(Description = "F# 333-27")]
            public async Task MinusFSharp() 
                => await _clientFSharp.GetAsync(FSharpUrl + "?v1=333&op=minus&v2=27");
        
            [Benchmark(Description = "C# 333-27")]
            public async Task MinusCSharp() 
                => await _clientCSharp.GetAsync(CSharpUrl + "?v1=333&op=minus&v2=27");
        
            [Benchmark(Description = "F# 7*176")]
            public async Task MultiplicationFSharp() 
                => await _clientFSharp.GetAsync(FSharpUrl + "?v1=7&op=multiply&v2=176");
        
            [Benchmark(Description = "C# 7*176")]
            public async Task MultiplicationCSharp() 
                => await _clientCSharp.GetAsync(CSharpUrl + "?v1=7&op=multiplication&v2=176");
            
            [Benchmark(Description = "F# 3356/2")]
            public async Task DivisionFSharp() 
                => await _clientFSharp.GetAsync(FSharpUrl + "?v1=3356&op=divide&v2=2");
        
            [Benchmark(Description = "C# 3356/2")]
            public async Task DivisionCSharp() 
                => await _clientCSharp.GetAsync(CSharpUrl + "?v1=3356&op=division&v2=2");
    }
}