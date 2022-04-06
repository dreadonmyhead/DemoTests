using NUnit.Framework;

namespace DemoTests.Test
{
    public class CheckboxTest : BaseTest
    {
        [Test]
        public static void TestFirstCheckbox()
        {
            checkboxPage.NavigateToPage();
            checkboxPage.ClickFirstChechbox();
            checkboxPage.VerifyTextResult();
        }

        [Test]
        public static void TestMultipleCheckboxes()
        {
            checkboxPage.NavigateToPage();
            checkboxPage.CheckAllCheckboxes();
            checkboxPage.VerifyButtonText();
        }

        [Test]
        public static void TestUncheckAllCheckboxes()
        {
            checkboxPage.NavigateToPage();
            checkboxPage.ClickOnButton();
            checkboxPage.VerifyAllCheckboxesUnchecked();
        }
    }
}
