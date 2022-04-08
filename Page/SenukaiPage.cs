using System;
using OpenQA.Selenium;

namespace DemoTests.Page
{
    public class SenukaiPage : BasePage
    {

        private const string pageAddress = "https://www.senukai.lt/";

        public SenukaiPage(IWebDriver webDriver) : base(webDriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != pageAddress)
            {
                Driver.Url = pageAddress;
            }
        }

        public void CloseCookies()
        {
            Cookie myCookie = new Cookie("CookieConsent",
                "{stamp:%275+tDR8KmtNfvY+vEAoxsL/hLP2isOuoWSh2T0gkhXcMh001Bg3wBaA==%27%2Cnecessary:true%2Cpreferences:false%2Cstatistics:false%2Cmarketing:false%2Cver:1%2Cutc:1649433333737%2Cregion:%27lt%27}",
                "www.senukai.lt", 
                "/",
                DateTime.Now.AddYears(10));
            Driver.Manage().Cookies.AddCookie(myCookie);
            Driver.Navigate().Refresh();
        }
    }
}
