using System;
using System.Linq;
using NUnit.Framework;

namespace DemoTests.Test
{
    public class SelectDemoTest : BaseTest
    {
        [TestCase(DayOfWeek.Monday, TestName = "Testing Monday")]
        [TestCase(DayOfWeek.Tuesday, TestName = "Testing Tuesday")]
        [TestCase(DayOfWeek.Wednesday, TestName = "Testing Wednesday")]
        [TestCase(DayOfWeek.Friday, TestName = "Testing Friday")]
        public static void TestSingleDropdown(DayOfWeek dayOfweek)
        {
            selectDemoPage.NavigateToPage();
            selectDemoPage.SelectFromDropdownByValue(dayOfweek);
            selectDemoPage.VerifyResultText(dayOfweek);
        }

        [Test]
        public static void TestMultipleDropdownWithOneOption()
        {
            string myTestText = "Ohio";
            selectDemoPage.NavigateToPage();
            selectDemoPage.SelectFromMultipleDropDownByText(myTestText);
            selectDemoPage.VerifySelectedOption(myTestText);
        }

        [TestCase("California", "New York", TestName = "Test California, New York")]
        [TestCase("Pennsylvania", "Ohio", "Florida", TestName = "Test Pennsylvania, Ohio, Florida")]
        [TestCase("Washington", "California", "Texas", "Ohio", TestName = "Test Washington, California, Texas, Ohio")]
        public static void TestMultipleDropdown(params string[] states)
        {
            selectDemoPage.NavigateToPage();
            selectDemoPage.SelectFromMultipleDropdown(states.ToList());
            selectDemoPage.VerifySelectedOptions(states.ToList());
        }
    }
}
