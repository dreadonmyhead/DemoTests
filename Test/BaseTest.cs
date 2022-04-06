using DemoTests.Drivers;
using DemoTests.Page;
using DemoTests.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace DemoTests.Test
{
    public class BaseTest
    {
        protected static CheckboxPage checkboxPage;
        protected static FirstInputPage firstInputPage;
        protected static SelectDemoPage selectDemoPage;
        private static IWebDriver driver;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            driver = CustomDriver.GetChrome();
            checkboxPage = new CheckboxPage(driver);
            firstInputPage = new FirstInputPage(driver);
            selectDemoPage = new SelectDemoPage(driver);
        }

        [TearDown]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.TakeScreenshot(driver);
            }
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            driver.Quit();
        }
    }
}
