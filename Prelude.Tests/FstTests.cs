using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class FstTests
    {
        [Test]
        public void FstTest()
        {
            Assert.That((65, 'A').Fst(), Is.EqualTo(65));
        }
    }
}