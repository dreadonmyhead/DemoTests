using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace DemoTests.Page
{
    public class SelectDemoPage : BasePage
    {
        private const string address = "http://demo.seleniumeasy.com/basic-select-dropdown-demo.html";

        private const string staticText = "Day selected :- ";
        private SelectElement dropdownElement => new SelectElement(Driver.FindElement(By.Id("select-demo")));
        private SelectElement multiDropdownElement => new SelectElement(Driver.FindElement(By.Id("multi-select")));
        private IWebElement resultElement => Driver.FindElement(By.CssSelector(".selected-value"));

        public SelectDemoPage(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != address)
            {
                Driver.Url = address;
            }
        }

        public void SelectFromDropdownByIndex(int index)
        {
            dropdownElement.SelectByIndex(index);
        }

        public void SelectFromDropdownByVisibleTest(string visibleText)
        {
            dropdownElement.SelectByText(visibleText);
        }

        public void SelectFromDropdownByValue(DayOfWeek value)
        {
            dropdownElement.SelectByValue(value.ToString());
        }

        public void SelectFromMultipleDropDownByText(string text)
        {
            multiDropdownElement.DeselectAll();
            multiDropdownElement.SelectByText(text);
        }

        public void SelectFromMultipleDropdown(List<string> states)
        {
            multiDropdownElement.DeselectAll();

            Actions action = new Actions(Driver);

            foreach (IWebElement option in multiDropdownElement.Options)
            {
                action.KeyDown(Keys.Control);
                if (states.Contains(option.Text))
                {
                    if (!option.Selected)
                    {
                        option.Click();
                    }
                }
            }
            action.KeyUp(Keys.Control);
            action.Build().Perform();
        }

        public void VerifySelectedOption(string resultText)
        {
            IWebElement selectedOption = multiDropdownElement.SelectedOption;

            Assert.AreEqual(resultText, selectedOption.Text, $"Wrong selected option text, actual {selectedOption.Text}");
        }

        public void VerifySelectedOptions(List<string> states)
        {
            foreach (IWebElement option in multiDropdownElement.Options)
            {
                if (states.Contains(option.Text))
                {
                    Assert.IsTrue(option.Selected);
                }
            }

        }

        public void VerifyResultText(DayOfWeek result)
        {
            string expectedResultText = staticText + result.ToString();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(resultElement, expectedResultText));

            Assert.IsTrue(resultElement.Text.Contains(result.ToString()), $"Text is wrong, actual text is {resultElement.Text}");
        }

    }
}
