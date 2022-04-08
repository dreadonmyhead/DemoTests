using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace DemoTests.Drivers
{
    public class CustomDriver
    {
        public static IWebDriver GetChrome()
        {
            Browsers webdriver = Browsers.Chrome;
            return GetDriver(webdriver);
        }

        public static IWebDriver GetFirefox()
        {
            return GetDriver(Browsers.Firefox);
        }

        public static IWebDriver GetIncognitoChrome()
        {
            return GetDriver(Browsers.IncognitoChrome);
        }

        private static IWebDriver GetDriver(Browsers browser)
        {
            IWebDriver driver;
            switch (browser)
            {
                case Browsers.Chrome:
                    driver = new ChromeDriver();
                    break;
                case Browsers.Firefox:
                    driver = new FirefoxDriver();
                    break;
                case Browsers.IncognitoChrome:
                    driver = GetChromeWithIncognitoOption();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }

        private static IWebDriver GetChromeWithIncognitoOption()
        {
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("incognito");
            options.AddArgument("disable-infobars");
            //options.AddArguments("incognito", "disable-infobars");
            return new ChromeDriver(options);
        }
    }
}
