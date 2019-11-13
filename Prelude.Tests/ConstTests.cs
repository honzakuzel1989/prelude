using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class ConstTests
    {
        [Test]
        public void ConstTest()
        {
            Assert.That('A'.Const('B'), Is.EqualTo('A'));
        }
    }
}