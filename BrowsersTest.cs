using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace DemoTests
{
    class BrowsersTest
    {

        [Test]
        public static void TestYahooWithFirefox()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://login.yahoo.com/";
            driver.Quit();
        }

        [Test]
        public static void TestYahooWithChrome()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://login.yahoo.com/";
            driver.Manage().Window.Maximize();

            IWebElement inputField = driver.FindElement(By.Id("login-username"));
            inputField.SendKeys("test");
            IWebElement button = driver.FindElement(By.Name("signin"));
            button.Click();

            driver.Quit();
        }

        [Test]
        public static void TestSeleniumFirstInputBlock()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://demo.seleniumeasy.com/basic-first-form-demo.html";
            driver.Manage().Window.Maximize();

            string myText = "katinukai";
            IWebElement inputField = driver.FindElement(By.Id("user-message"));
            inputField.SendKeys(myText);

            Thread.Sleep(2000); //todo
            driver.FindElement(By.Id("at-cv-lightbox-close")).Click();

            IWebElement button = driver.FindElement(By.CssSelector("#get-input > button"));
            button.Click();

            IWebElement resultElement = driver.FindElement(By.Id("display"));
            Assert.AreEqual(myText, resultElement.Text, "Text is wrong");

            driver.Quit();
        }

    }
}
