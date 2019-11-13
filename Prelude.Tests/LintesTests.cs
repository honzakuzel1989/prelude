using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class LintesTests
    {
        [Test]
        public void LinesEmptyStringTest()
        {
            Assert.That(String.Empty.Lines(), Is.EqualTo(new string[]{}));
        }

        [Test]
        public void LinesOneLineTest()
        {
            Assert.That("jedna\ndve".Lines(), Is.EqualTo(new string[]{"jedna", "dve"}));
        }

        [Test]
        public void LinesTest()
        {
            Assert.That("jedna\ndve\ntri\n   \nctyri".Lines(), Is.EqualTo(new string[]{"jedna", "dve", "tri", "   ", "ctyri"}));
        }
    }
}