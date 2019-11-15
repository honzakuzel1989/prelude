using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class ProductTests
    {
        [Test]
        public void ProductIntTests()
        {
            var xs = new int[]{1,2,3,4,5,6,7,8,9,10};
            Assert.That(xs.Product(), Is.EqualTo(3628800));
        }

        [Test]
        public void ProductDoubleTests()
        {
            var xs = new double[]{0.5, 10, 1.1};
            Assert.That(xs.Product(), Is.EqualTo(5.5));
        }

        [Test]
        public void ProductEmptyTests()
        {
            var xs = new int[]{};
            Assert.That(xs.Product(), Is.EqualTo(1));
        }
    }
}