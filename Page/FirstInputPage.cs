
using NUnit.Framework;
using OpenQA.Selenium;

namespace DemoTests.Page
{
    public class FirstInputPage : BasePage
    {
        private IWebElement firstInputField => Driver.FindElement(By.Id("sum1"));
        private IWebElement secondInputField => Driver.FindElement(By.Id("sum2"));
        private IWebElement calculateButton => Driver.FindElement(By.CssSelector("#gettotal > button"));
        private IWebElement resultFromPage => Driver.FindElement(By.Id("displayvalue"));

        public FirstInputPage(IWebDriver webdriver) : base (webdriver) { }

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
