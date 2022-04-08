using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DemoTests.Page
{
    public class SebPage : BasePage
    {
        private const string AddressUrl = "https://www.seb.lt/privatiems/kreditai/busto-kreditas#paragraph7764";
        private IWebElement incomeInputField => Driver.FindElement(By.Id("income"));
        private IWebElement calculateButton => Driver.FindElement(By.Id("calculate"));
        private SelectElement cityDropdown => new SelectElement(Driver.FindElement(By.Id("city")));
        private string resultLoanAmount => Driver.FindElement(By.CssSelector(".controls.controls-row.ng-binding > strong")).Text;
        public SebPage(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != AddressUrl)
            {
                Driver.Url = AddressUrl;
            }
        }

        public void InsertIncome(string incomeAmount)
        {
            Driver.SwitchTo().Frame(0);
            incomeInputField.Clear();
            incomeInputField.SendKeys(incomeAmount);
        }

        public void SelectValueFromCityDropdown(string value)
        {
            cityDropdown.SelectByValue(value);
        }

        public void CalculateLoanAmount()
        {
            calculateButton.Click();
        }

        public void AcceptCookies()
        {
            Cookie myCookie = new Cookie("SEBConsents",
                "%7B%22version%22%3A%222%22%2C%22consents%22%3A%7B%22mandatory%22%3Atrue%2C%22statistical%22%3Atrue%2C%22simplified_login%22%3Atrue%2C%22marketing%22%3Atrue%7D%7D",
                ".seb.lt",
                "/",
                DateTime.Now.AddDays(5));
            Driver.Manage().Cookies.AddCookie(myCookie);
            Driver.Navigate().Refresh();
        }

        public void VerifyResult(int loanIWant)
        {
            Assert.IsTrue(loanIWant < Int32.Parse(resultLoanAmount.Replace(" ", "")), "Nope, no loan for me");
        }
    }
}
