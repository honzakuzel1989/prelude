using System.Linq;
using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class ReplicateTests
    {
        [Test]
        public void ReplicateTest()
        {
            Assert.That(5.Replicate(25), Is.EqualTo(Enumerable.Repeat(5, 25)));
        }
    }
}