using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;

namespace Cache.Test.Internal
{
    [SimpleJob(launchCount: 3, warmupCount: 3, targetCount: 3)]
    public class BloomFilterBenchmark
    {
        private readonly byte[] data;
        private readonly SHA256 _sha256 = SHA256.Create();

        public BloomFilterBenchmark()
        {
            data = new byte[1000];
            new Random(42).NextBytes(data);
        }

        [Benchmark]
        public byte[] Sha256() => _sha256.ComputeHash(data);
    }
}