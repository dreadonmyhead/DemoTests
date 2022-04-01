using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace DemoTests
{
    class BrowserHW
    {

        [TestCase("Chrome", "Chrome 100 on Windows 10", TestName = "Testing Chrome")]
        [TestCase("Firefox", "Firefox 98 on Windows 10", TestName = "Testing Firefox")]
        [TestCase("Edge", "Edge 99 on Windows 10", TestName = "Testing Edge")]
        public static void TestBrowsers(string browser, string text)
        {
            IWebDriver _driver = null;

            if ("Chrome".Equals(browser))
            {
                _driver = new ChromeDriver();
            }

            if ("Firefox".Equals(browser))
            {
                _driver = new FirefoxDriver();
            }

            if ("Edge".Equals(browser))
            {
                _driver = new EdgeDriver();
            }


            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent");
            IWebElement actualResult = _driver.FindElement(By.CssSelector(".simple-major"));

            Assert.AreEqual(text, actualResult.Text, $"Browser is not {browser}");
            _driver.Quit();
        }
    }
}
