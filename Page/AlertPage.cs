using NUnit.Framework;
using OpenQA.Selenium;

namespace DemoTests.Page
{
    public class AlertPage : BasePage
    {
        private const string pageAddress = "http://demo.seleniumeasy.com/javascript-alert-box-demo.html";

        private IWebElement firstAlertButton => Driver.FindElement(By.XPath("//button[@onclick='myAlertFunction()']"));
        private IWebElement secondAlertButton => Driver.FindElement(By.XPath("//button[@onclick='myConfirmFunction()']"));
        private IWebElement thirdAlertButton => Driver.FindElement(By.XPath("//button[@onclick='myPromptFunction()']"));
        private IWebElement secondAlertResultElement => Driver.FindElement(By.Id("confirm-demo"));
        private IWebElement thirdAlertResultElement => Driver.FindElement(By.Id("prompt-demo"));

        public AlertPage(IWebDriver webDriver) : base(webDriver) { }


        public AlertPage NavigateToPage()
        {
            if (Driver.Url != pageAddress)
            {
                Driver.Url = pageAddress;
            }
            return this;
        }

        public AlertPage ClickOnFirstAlertButton()
        {
            firstAlertButton.Click();
            return this;
        }

        public AlertPage ClickOnSecondAlertButton()
        {
            secondAlertButton.Click();
            return this;
        } 
        
        public void ClickOnThirdAlertButton()
        {
            thirdAlertButton.Click();
        }

        public AlertPage AsseptAlert()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.Accept();
            return this;
        }
        public AlertPage CloseSecondAlert(bool shouldAcceptAlert)
        {
            IAlert alert = Driver.SwitchTo().Alert();
            if (shouldAcceptAlert)
            {
                alert.Accept();
            }
            else
            {
                alert.Dismiss();
            }
            return this;
        }

        public void InsertTextAndAcceptAlert(string myText)
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.SendKeys(myText);
            alert.Accept();
        }

        public AlertPage VerifySecondAlertText(bool shouldAcceptAlert)
        {
            if (shouldAcceptAlert)
            {
                Assert.IsTrue("You pressed OK!".Equals(secondAlertResultElement.Text), $"Text was wrong, actual text {secondAlertResultElement.Text}");
            }
            else
            {
                Assert.IsTrue("You pressed Cancel!".Equals(secondAlertResultElement.Text), $"Text was wrong, actual text {secondAlertResultElement.Text}");
            }
            return this;
        }

        public void VerifyThirdAlertText(string myText)
        {
            Assert.IsTrue(thirdAlertResultElement.Text.Contains(myText), $"Text is wrong, actual text {thirdAlertResultElement.Text}");
        }
    }
}
