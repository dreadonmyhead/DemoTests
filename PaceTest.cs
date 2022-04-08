using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace DemoTests
{
    public class PaceTest
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.active.com/fitness/calculators/pace");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => _driver.FindElement(By.CssSelector(".optanon-alert-box-button-middle.accept-cookie-container")).Displayed);
            _driver.FindElement(By.CssSelector(".optanon-alert-box-button-middle.accept-cookie-container")).Click();

        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public static void TestPace()
        {
            IWebElement hours = _driver.FindElement(By.Name("time_hours"));
            hours.SendKeys("1");
            IWebElement minutes = _driver.FindElement(By.Name("time_minutes"));
            minutes.SendKeys("5");
            IWebElement distance = _driver.FindElement(By.Name("distance"));
            distance.SendKeys("13");
            _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > span > span")).Click();
            _driver.FindElement(By.XPath("//*[@id='calculator-pace']/form/div[3]/div/span/ul/li[1]/a")).Click();

            _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(4) > div > span > span > span.selectboxit-arrow-container > i")).Click();
            _driver.FindElement(By.XPath("//*[@id='calculator-pace']/form/div[4]/div/span/ul/li[1]/a")).Click();

            _driver.FindElement(By.CssSelector(".btn.btn-medium-yellow.calculate-btn")).Click();
            Assert.IsTrue(_driver.FindElement(By.Name("pace_hours")).GetAttribute("value").Equals("00"), "Hours are wrong");
            Assert.IsTrue(_driver.FindElement(By.Name("pace_minutes")).GetAttribute("value").Equals("05"), "Minutes are wrong");
            Assert.IsTrue(_driver.FindElement(By.Name("pace_seconds")).GetAttribute("value").Equals("00"), "Seconds are wrong");
        }
    }
}
