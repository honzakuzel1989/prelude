using NUnit.Framework;
using System.Collections.Generic;

namespace System.Prelude.Test
{
    public class BreakTests
    {
        [Test]
        public void BreakIsWhiteSpaceTest()
        {
            string str = "jedna dve honza jde";

            var (first, rest) = str.Break(char.IsWhiteSpace);

            Assert.That((string.Join(string.Empty, first), string.Join(string.Empty, rest)), 
                Is.EqualTo(("jedna", " dve honza jde")));
        }

        [Test]
        public void BreakNoWhiteSpaceTest()
        {
            string str = "jednadve";

            var (first, rest) = str.Break(char.IsWhiteSpace);

            Assert.That((string.Join(string.Empty, first), string.Join(string.Empty, rest)), 
                Is.EqualTo(("jednadve", "")));
        }
    }
}