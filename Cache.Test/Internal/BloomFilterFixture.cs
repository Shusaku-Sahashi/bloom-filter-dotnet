using System;
using System.Linq;
using System.Security.Cryptography;
using Cache.Internal;
using NUnit.Framework;

namespace Cache.Test.Internal
{
    [TestFixture]
    public class BloomFilterFixture
    {
        private static readonly MD5 Md5 = MD5.Create();

        [Test]
        public void AddValue()
        {
            var bf = new BloomFilter(10 ^ 6, 0.1);

            bf.Put(BitConverter.ToUInt64(Md5.ComputeHash(BitConverter.GetBytes(100)).Take(8).ToArray()));
            bf.Put(BitConverter.ToUInt64(Md5.ComputeHash(BitConverter.GetBytes(300)).Take(8).ToArray()));

            var actual = bf.Has(BitConverter.ToUInt64(Md5.ComputeHash(BitConverter.GetBytes(100)).Take(8).ToArray()));
            var actual300 = bf.Has(BitConverter.ToUInt64(Md5.ComputeHash(BitConverter.GetBytes(300)).Take(8).ToArray()));
            var actual400 = bf.Has(BitConverter.ToUInt64(Md5.ComputeHash(BitConverter.GetBytes(400)).Take(8).ToArray()));

            Assert.IsTrue(actual);
            Assert.IsTrue(actual300);
            Assert.IsFalse(actual400);
        }
    }
}