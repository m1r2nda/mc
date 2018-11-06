using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class FullTest : SeleniumTestBase
    {
        private static Pages pages = new Pages();

        [Test]
        public void MyFullTest()
        {
            pages.AddBook();
            pages.CourierDelivery();
        }
    }
}