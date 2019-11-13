using NUnit.Framework;
using System.Collections.Generic;

namespace System.Prelude.Tests
{
    public class SpanTests
    {
        [Test]
        public void SpanIsDigitTest()
        {
            string str = "123abc456";

            var (digits, rest) = str.Span(char.IsDigit);

            Assert.That((string.Join(string.Empty, digits), string.Join(string.Empty, rest)), 
                Is.EqualTo(("123", "abc456")));
        }
    }
}