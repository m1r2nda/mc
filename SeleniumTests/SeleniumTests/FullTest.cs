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
        [Test]
        public void MyFullTest()
        {
            var pages = new Pages();

            pages.AddBookInBasket();
            pages.CourierDelivery();
        }
    }
}