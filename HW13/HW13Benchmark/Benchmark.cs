using System.Reflection;
using BenchmarkDotNet.Attributes;

namespace HW13Benchmark
{
    [MemoryDiagnoser]
    [MinColumn]
    [MaxColumn]
    [MedianColumn]
    [MeanColumn]
    [StdDevColumn]
    public class Benchmark
    {
        private Methods methods;
        private string _testNumber;
        private static MethodInfo _methodFromTest;

        [GlobalSetup]
        public void Setup()
        {
            methods = new Methods();
            _methodFromTest = typeof(Methods).GetMethod("Reflection");
            _testNumber = "10";
        }

        [Benchmark(Description = "simple method")]
        public void TestSimpleMethod()
        {
            methods.Simple(_testNumber);
        }

        [Benchmark(Description = "static method")]
        public void TestStaticMethod()
        {
            Methods.Static(_testNumber);
        }

        [Benchmark(Description = "virtual method")]
        public void TestVirtualMethod()
        {
            methods.Virtual(_testNumber);
        }

        [Benchmark(Description = "generic method")]
        public void TestGenericMethod()
        {
            methods.Generic<string>(_testNumber);
        }

        [Benchmark(Description = "reflection method")]
        public void TestReflectionMethod()
        {
            _methodFromTest.Invoke(methods, new object[] {_testNumber});
        }

        [Benchmark(Description = "dynamic method")]
        public void TestDynamicMethod()
        {
            methods.Dynamic(_testNumber);
        }
    }
}