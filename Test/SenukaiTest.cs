using NUnit.Framework;

namespace DemoTests.Test
{
    public class SenukaiTest : BaseTest
    {
        [Test]
        public static void TestSenukaiCookies()
        {
            senukaiPage.NavigateToPage();
            senukaiPage.CloseCookies();
        }
    }
}
