using DemoTests.Test;
using NUnit.Framework;

namespace DemoTests
{
    public class SebTest : BaseTest
    {

        [Test]
        public static void TestSebCalculator()
        {
            sebPage.NavigateToPage();
            sebPage.AcceptCookies();
            sebPage.InsertIncome("1000");
            sebPage.SelectValueFromCityDropdown("Klaipeda");
            sebPage.CalculateLoanAmount();
            sebPage.VerifyResult(75000);
        }
    }
}
