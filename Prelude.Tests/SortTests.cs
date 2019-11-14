using NUnit.Framework;
using System.Collections.Generic;

namespace System.Prelude.Tests
{
    public class SortTests
    {
        [Test]
        public void SortTest()
        {
            string str = "123abc456";
            var stra = str.ToCharArray();

            Array.Sort(stra);

            Assert.That(str.Sort(), Is.EqualTo(stra));
        }
    }
}