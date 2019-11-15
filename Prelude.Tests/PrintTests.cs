using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class PrintTests
    {
        [Test]
        public void PrintTest()
        {
            var sb = new StringBuilder();
            Assert.That(5.Print(sb).ToString(), Is.EqualTo("5"));
        }

        [Test]
        public void PrintWithoutSbParamTest()
        {
            var sb = new StringBuilder();
            Assert.That("Hello".Print().ToString(), Is.EqualTo("Hello"));
        }
    }
}