using NUnit.Framework;

namespace System.Prelude.Test
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