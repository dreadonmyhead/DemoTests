using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace DemoTests
{
    class SeleniumSecondTest
    {

        private static IWebDriver driver;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            driver.Url = "http://demo.seleniumeasy.com/basic-first-form-demo.html";
            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(tempDriver => tempDriver.FindElement(By.Id("at-cv-lightbox-close")).Displayed);
            driver.FindElement(By.Id("at-cv-lightbox-close")).Click();
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            driver.Quit();
        }

        [TestCase("2", "2", "4", TestName = "Test 2 plus 2")]
        [TestCase("-5", "3", "-2", TestName = "Test -5 plus 3")]
        [TestCase("a", "b", "NaN", TestName = "Test a plus b")]
        public static void TestSumFromSeleniumWebPage(string firstParameter, string secondParameter, string sum)
        {
            IWebElement firstInputField = driver.FindElement(By.Id("sum1"));
            IWebElement secondInputField = driver.FindElement(By.Id("sum2"));

            firstInputField.Clear();
            firstInputField.SendKeys(firstParameter);
            secondInputField.Clear();
            secondInputField.SendKeys(secondParameter);

            driver.FindElement(By.CssSelector("#gettotal > button")).Click();
            IWebElement resultFromPage = driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(sum, resultFromPage.Text, "Actual result differs from expected");
        }
    }
}
