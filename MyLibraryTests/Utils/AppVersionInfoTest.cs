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
            var appVersionInfo = new AppVersionInfo()
            {
                MajorVersion = 1,
                MinorVersion = 2,
                PatchVersion = 3,
                Updated = "20250321",
                SuffixId = "b",
            };

            appVersionInfo.UpdateTile();
            Assert.That(appVersionInfo.Title, Is.EqualTo("My Library   version : 1.2.3 (20250321b)"));
        }
    }
}