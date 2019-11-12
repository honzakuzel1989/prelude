using NUnit.Framework;

namespace Prelude.Tests
{
    public class SndTests
    {
        [Test]
        public void SndTest()
        {
            Assert.That((65, 'A').Fst(), Is.EqualTo('A'));
        }
    }
}