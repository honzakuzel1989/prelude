using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class SumTests
    {
        [Test]
        public void SumIntTests()
        {
            var xs = new int[]{1,2,3,4,5};
            Assert.That(xs.Sum(), Is.EqualTo(15));
        }

        [Test]
        public void SumDoubleTests()
        {
            var xs = new double[]{0.5, 10, 1.1};
            Assert.That(xs.Sum(), Is.EqualTo(11.6));
        }

        [Test]
        public void SumEmptyTests()
        {
            var xs = new int[]{};
            Assert.That(xs.Sum(), Is.EqualTo(0));
        }
    }
}