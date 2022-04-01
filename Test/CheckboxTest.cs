using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoTests.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoTests.Test
{
    public class CheckboxTest
    {
        private static IWebDriver driver;
        private static CheckboxPage page;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            driver.Url = "http://demo.seleniumeasy.com/basic-checkbox-demo.html";
            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            page = new CheckboxPage(driver);
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            page.CloseBrowser();
        }

        [Test]
        public static void TestFirstCheckbox()
        {
            page.ClickFirstChechbox();
            page.VerifyTextResult();
        }

        [Test]
        public static void TestMultipleCheckboxes()
        {
            page.CheckAllCheckboxes();
            page.VerifyButtonText();
        }
    }
}
