using NUnit.Framework;

namespace Prelude.Tests
{
    public class OrdTests
    {
        [Test]
        public void OrdTest()
        {
            Assert.That('A'.Ord(), Is.EqualTo(65));
        }
    }
}