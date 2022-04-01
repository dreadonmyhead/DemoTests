using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoTests
{
    class CheckboxDemo
    {
        private static IWebDriver driver;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            driver.Url = "http://demo.seleniumeasy.com/basic-checkbox-demo.html";
            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            driver.Quit();
        }

        [Test]
        public static void TestMultipleCheckboxes()
        {
            IReadOnlyCollection<IWebElement> checkboxes = driver.FindElements(By.CssSelector(".cb1-element"));

            foreach (IWebElement checkbox in checkboxes)
            {
                if (!checkbox.Selected)
                {
                    checkbox.Click();
                }

            }

            IWebElement button = driver.FindElement(By.Id("check1"));

            Assert.AreEqual("Uncheck All", button.GetAttribute("value"), "Wrong value");
        }

        [Test]
        public static void TestFirstCheckbox()
        {
            IWebElement firstCheckbox = driver.FindElement(By.Id("isAgeSelected"));
            firstCheckbox.Click();
            IWebElement resultElement = driver.FindElement(By.Id("txtAge"));
            Assert.IsTrue("Success - Check box is checked".Equals(resultElement.Text), $"Text is not the same, actual text is {resultElement.Text}");

        }


    }
}
