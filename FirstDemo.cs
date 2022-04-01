using System;
using System.Threading;
using NUnit.Framework;

namespace DemoTests
{
    public class FirstDemo
    {
        [Test]
        public static void TestIf4IsEven()
        {
            Assert.AreEqual(0, 4 % 2, "4 is not even");            
        }

        [Test]
        public static void TestNowIs20Hour()
        {
            DateTime currentTime = DateTime.Now;
            Assert.AreEqual(20, currentTime.Hour, "Now is not 20 hour");
        }

        [Test]
        public static void Test995()
        {
            int leftover = 995 % 3;
            Assert.IsTrue(0 == leftover, "995 divides by 3 without any leftover");
        }

        [Test]
        public static void TestTodayIsWednesday()
        {
            Assert.AreEqual(DayOfWeek.Wednesday, DateTime.Now.DayOfWeek, "Now is not Wednesday");
        }

        [Test]
        public static void TestNowWait()
        {
            Thread.Sleep(5000);
            Assert.Pass();
        }

        [Test]
        public static void TestEvenNumberBetween1And10()
        {
            int counter = 0;
            for (int i = 1; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    counter++;
                }
            }
            Assert.AreEqual(4, counter, "We not have 4 even numbers between 1 and 10");
        }
    }
}
