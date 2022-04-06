using NUnit.Framework;

namespace DemoTests.Test
{
    public class FirstInputTest : BaseTest
    {
        [TestCase("2", "2", "4", TestName = "Test 2 plus 2")]
        [TestCase("-5", "3", "-2", TestName = "Test -5 plus 3")]
        [TestCase("a", "b", "NaN", TestName = "Test a plus b")]
        public static void TestSumFromSeleniumWebPage(string firstParameter, string secondParameter, string sum)
        {
            firstInputPage.NavigateToPage();
            firstInputPage.ClosePopup();
            firstInputPage.InsertBothInputs(firstParameter, secondParameter);
            firstInputPage.ClickCalculateButton();
            firstInputPage.VerifyResult(sum);
        }
    }
}
