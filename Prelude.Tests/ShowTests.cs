using NUnit.Framework;
using System.Collections.Generic;

namespace System.Prelude.Tests
{
    public class ShowTests
    {
        [Test]
        public void ShowTest()
        {
            Assert.That((6 + 2).Show(), Is.EqualTo(8.ToString()));
        }
    }
}