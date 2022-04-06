using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DemoTests.Page
{
    public class FirstInputPage : BasePage
    {
        private const string pageAddress = "http://demo.seleniumeasy.com/basic-first-form-demo.html";
        private IWebElement firstInputField => Driver.FindElement(By.Id("sum1"));
        private IWebElement secondInputField => Driver.FindElement(By.Id("sum2"));
        private IWebElement calculateButton => Driver.FindElement(By.CssSelector("#gettotal > button"));
        private IWebElement resultFromPage => Driver.FindElement(By.Id("displayvalue"));

        private IWebElement popupCloseElement => Driver.FindElement(By.Id("at-cv-lightbox-close"));

        public FirstInputPage(IWebDriver webdriver) : base (webdriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != pageAddress)
            {
                Driver.Url = pageAddress;
            }
        }

        public void ClosePopup()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(tempDriver => tempDriver.FindElement(By.Id("at-cv-lightbox-close")).Displayed);
            popupCloseElement.Click();
        }

        public void InsertFirstInput(string firstParameter)
        {
            firstInputField.Clear();
            firstInputField.SendKeys(firstParameter);
        }

        public void InsertSecondInput(string secondParameter)
        {
            secondInputField.Clear();
            secondInputField.SendKeys(secondParameter);
        }

        public void InsertBothInputs(string firstInput, string secondInput)
        {
            InsertFirstInput(firstInput);
            InsertSecondInput(secondInput);
        }

        public void ClickCalculateButton()
        {
            calculateButton.Click();
        }

        public void VerifyResult(string sum)
        {
            Assert.AreEqual(sum, resultFromPage.Text, "Actual result differs from expected");
        }
    }
}
