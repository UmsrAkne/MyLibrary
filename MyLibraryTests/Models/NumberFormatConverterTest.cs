using MyLibrary.Converters;
using NUnit.Framework;

namespace MyLibraryTests.Models
{
    public class NumberFormatConverterTest
    {
        [Test]
        [TestCase(1, "D4", "0001")]
        [TestCase(10, "D4", "0010")]
        [TestCase(1, "D3", "001")]
        [TestCase(10, "D3", "010")]
        [TestCase(1, "D1", "1")]
        [TestCase(10, "D1", "10")]
        public void ConvertTest(int input, string format, string result)
        {
            var c = new NumberFormatConverter()
            {
                Format = format,
            };

            Assert.That(c.Convert(input, typeof(string), null, null), Is.EqualTo(result));
        }

        [Test]
        public void ConvertTest_0の時の非表示のテスト()
        {
            var c = new NumberFormatConverter
            {
                VisibleWhenZero = true,
            };

            Assert.That(c.Convert(0, typeof(string), null, null), Is.EqualTo(string.Empty));
        }
    }
}