using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class SeleniumTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        [Test]
        public void MyFirstSeleniumTest()
        {
            driver.Navigate().GoToUrl("http://www.google.com/");
            driver.FindElement(By.Name("q")).SendKeys("Testing with Selenium is very-very-very fun!");
            driver.FindElement(By.Name("btnK")).Click();
            Assert.That(driver.Title.Contains("Testing with Selenium is very-very-very fun! - Поиск в Google"), "Перешли на неверную страницу");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver = null;
        }
    }
}
