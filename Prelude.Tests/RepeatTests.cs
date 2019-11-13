using System.Linq;
using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class RepeatTests
    {
        [Test]
        public void RepeatTest()
        {
            Assert.That(5.Repeat().Take(10), Is.EqualTo(Enumerable.Repeat(5, 10)));
        }
    }
}