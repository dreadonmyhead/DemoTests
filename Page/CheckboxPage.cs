using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;

namespace DemoTests.Page
{
    public class CheckboxPage : BasePage
    {
        private IWebElement firstCheckbox => Driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement resultElement => Driver.FindElement(By.Id("txtAge"));
        private IReadOnlyCollection<IWebElement> checkboxes => Driver.FindElements(By.CssSelector(".cb1-element"));
        private IWebElement button => Driver.FindElement(By.Id("check1"));

        public CheckboxPage(IWebDriver webDriver) : base(webDriver)
        {

        }

        public void ClickFirstChechbox()
        {
            CheckFirstCheckbox(true);
        }

        public void ClickButton()
        {
            button.Click();
        }

        private void CheckFirstCheckbox(bool shouldBeChecked)
        {
            if (shouldBeChecked != firstCheckbox.Selected)
            {
                firstCheckbox.Click();
            }
        }

        public void CheckAllCheckboxes()
        {
            CheckFirstCheckbox(false);

            foreach (IWebElement checkbox in checkboxes)
            {
                if (!checkbox.Selected)
                {
                    checkbox.Click();
                }

            }
        }

        public void VerifyButtonText()
        {
            Assert.AreEqual("Uncheck All", button.GetAttribute("value"), "Wrong value");
        }

        public void VerifyTextResult()
        {
            Assert.IsTrue("Success - Check box is checked".Equals(resultElement.Text), $"Text is not the same, actual text is {resultElement.Text}");
        }
    }
}
