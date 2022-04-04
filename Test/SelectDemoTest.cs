using System;
using System.Linq;
using DemoTests.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoTests.Test
{
    public class SelectDemoTest
    {

        private static IWebDriver driver;
        private static SelectDemoPage page;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            page = new SelectDemoPage(driver);
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            driver.Quit();
        }

        [TestCase(DayOfWeek.Monday, TestName = "Testing Monday")]
        [TestCase(DayOfWeek.Tuesday, TestName = "Testing Tuesday")]
        [TestCase(DayOfWeek.Wednesday, TestName = "Testing Wednesday")]
        [TestCase(DayOfWeek.Friday, TestName = "Testing Friday")]
        public static void TestSingleDropdown(DayOfWeek dayOfweek)
        {
            page.NavigateToPage();
            page.SelectFromDropdownByValue(dayOfweek);
            page.VerifyResultText(dayOfweek);
        }

        [Test]
        public static void TestMultipleDropdownWithOneOption()
        {
            string myTestText = "Ohio";
            page.NavigateToPage();
            page.SelectFromMultipleDropDownByText(myTestText);
            page.VerifySelectedOption(myTestText);
        }

        [TestCase("California", "New York", TestName = "Test California, New York")]
        [TestCase("Pennsylvania", "Ohio", "Florida", TestName = "Test Pennsylvania, Ohio, Florida")]
        [TestCase("Washington", "California", "Texas", "Ohio", TestName = "Test Washington, California, Texas, Ohio")]
        public static void TestMultipleDropdown(params string[] states)
        {
            page.NavigateToPage();
            page.SelectFromMultipleDropdown(states.ToList());
            page.VerifySelectedOptions(states.ToList());

        }
    }
}
