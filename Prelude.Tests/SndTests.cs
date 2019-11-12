using NUnit.Framework;

namespace System.Prelude.Test
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