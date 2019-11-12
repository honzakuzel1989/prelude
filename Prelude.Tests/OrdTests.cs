using NUnit.Framework;

namespace System.Prelude.Test
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