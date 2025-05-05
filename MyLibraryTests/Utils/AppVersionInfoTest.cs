using NUnit.Framework;
using MyLibrary.Utils;

namespace MyLibraryTests.Utils
{
    [TestFixture]
    public class AppVersionInfoTest
    {
        [Test]
        public void TitleTest()
        {
            var appVersionInfo = new AppVersionInfo();
            Assert.That(appVersionInfo.Title, Is.EqualTo("My Library ver:1.0.0"));
        }
    }
}