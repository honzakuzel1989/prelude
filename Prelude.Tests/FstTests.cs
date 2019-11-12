using NUnit.Framework;

namespace System.Prelude.Test
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