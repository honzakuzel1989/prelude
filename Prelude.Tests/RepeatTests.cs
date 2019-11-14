using System.Linq;
using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class RepeatTests
    {
        [Test]
        public void RepeatTest()
        {
            Assert.That(Enumerable.Take(5.Repeat(), 10), Is.EqualTo(Enumerable.Repeat(5, 10)));
        }
    }
}