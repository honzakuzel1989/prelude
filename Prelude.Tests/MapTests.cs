using NUnit.Framework;
using static System.Math;

namespace Prelude.Tests
{
    public class MapTests
    {
        [Test]
        public void MapAbsTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(xs.Map(Abs), Is.EqualTo(new int[]{1, 2, 3, 4, 5}));
        }
    }
}