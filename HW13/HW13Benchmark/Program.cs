using System;
using BenchmarkDotNet.Running;

namespace HW13Benchmark
{
    class Program
    {
        public static void Main() => BenchmarkRunner.Run<Benchmark>();
    }
}