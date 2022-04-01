
using OpenQA.Selenium;

namespace DemoTests.Page
{
    public class BasePage
    {

        protected static IWebDriver Driver;

        public BasePage(IWebDriver webdriver)
        {
            Driver = webdriver;
        }

        public void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}
