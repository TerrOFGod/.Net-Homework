using System;
using BenchmarkDotNet.Running;

namespace HW12
{
    internal static class Program
    {
        public static void Main() => BenchmarkRunner.Run<Benchmark>();
    }
}