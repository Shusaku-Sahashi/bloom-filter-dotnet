using BenchmarkDotNet.Running;
using Cache.Test.Internal;

namespace Cache.Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<BloomFilterBenchmark>();
        }
    }
}