using NUnit.Framework;

namespace DemoTests.Test
{
    public class AlertTest : BaseTest
    {
        [Test]
        public static void AcceptFirstAlertTest()
        {
            alertPage.NavigateToPage();
            alertPage.ClickOnFirstAlertButton();
            alertPage.AsseptAlert();
        }

        [TestCase(true, TestName = "Accept second alert")]
        [TestCase(false, TestName = "Dismiss second alert")]
        public static void DismissSecondAlertTest(bool shouldAcceptAlert)
        {
            alertPage.NavigateToPage()
                     .ClickOnSecondAlertButton()
                     .CloseSecondAlert(shouldAcceptAlert)
                     .VerifySecondAlertText(shouldAcceptAlert);
        }

        [Test]
        public static void InsertTextAndAcceptThirdAlertTest()
        {
            string myText = "katinukai";
            alertPage.NavigateToPage();
            alertPage.ClickOnThirdAlertButton();
            alertPage.InsertTextAndAcceptAlert(myText);
            alertPage.VerifyThirdAlertText(myText);
        }
    }
}
