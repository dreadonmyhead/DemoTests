using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;

namespace DemoTests.Page
{
    public class CheckboxPage : BasePage
    {
        private const string pageAddress = "http://demo.seleniumeasy.com/basic-checkbox-demo.html";
        private IWebElement firstCheckbox => Driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement resultElement => Driver.FindElement(By.Id("txtAge"));
        private IReadOnlyCollection<IWebElement> checkboxes => Driver.FindElements(By.CssSelector(".cb1-element"));
        private IWebElement button => Driver.FindElement(By.Id("check1"));

        public CheckboxPage(IWebDriver webDriver) : base(webDriver) { }

        public void ClickFirstChechbox()
        {
            CheckFirstCheckbox(true);
        }

        public void NavigateToPage()
        {
            if (Driver.Url != pageAddress)
            {
                Driver.Url = pageAddress;
            }
        }

        public void ClickButton()
        {
            button.Click();
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

        public void ClickOnButton()
        {
            CheckFirstCheckbox(false);
            if (!IsButtonWithValue(button, "Uncheck All"))
            {
                CheckAllCheckboxes(checkboxes);
            }
            button.Click();
        }

        public void VerifyButtonText()
        {
            Assert.IsTrue(IsButtonWithValue(button, "Uncheck All"), "Text is not correct");
        }

        public void VerifyTextResult()
        {
            Assert.IsTrue("Success - Check box is checked".Equals(resultElement.Text), $"Text is not the same, actual text is {resultElement.Text}");
        }

        public void VerifyAllCheckboxesUnchecked()
        {
            foreach (IWebElement checkbox in checkboxes)
            {
                Assert.IsFalse(checkbox.Selected);

                //Assert.IsTrue(!checkbox.Selected);
            }
            Assert.IsTrue(IsButtonWithValue(button, "Check All"), "Text is not correct");
        }

        private bool IsButtonWithValue(IWebElement button, string value)
        {
            return value.Equals(button.GetAttribute("value"));
        }

        private void CheckFirstCheckbox(bool shouldBeChecked)
        {
            if (shouldBeChecked != firstCheckbox.Selected)
            {
                firstCheckbox.Click();
            }
        }

        private void CheckAllCheckboxes(IReadOnlyCollection<IWebElement> checkboxes)
        {

            //WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("")));

            CheckFirstCheckbox(false);
            foreach (IWebElement checkbox in checkboxes)
            {
                if (!checkbox.Selected)
                {
                    checkbox.Click();
                }
            }
        }
    }
}
