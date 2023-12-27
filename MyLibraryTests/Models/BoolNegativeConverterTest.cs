using MyLibrary.Converters;
using NUnit.Framework;

namespace MyLibraryTests.Models
{
    [TestFixture]
    public class BoolNegativeConverterTest
    {
        [Test]
        public void ConvertTest()
        {
            var c = new BoolNegativeConverter();
            Assert.That(c.Convert(true, typeof(string), null, null), Is.EqualTo(false));
        }

        [Test]
        public void ConvertTest_2()
        {
            var c = new BoolNegativeConverter();
            Assert.That(c.Convert(false, typeof(string), null, null), Is.EqualTo(true));
        }
    }
}