using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Training
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
        public void TrainingTest()
        {
            //Тренировочные локаторы
            driver.Navigate().GoToUrl("https://www.labirint.ru");
            var books = driver.FindElements(By.ClassName("product-padding"));
            var links = driver.FindElements(By.CssSelector("a.cover"));
            var help = driver.FindElement(By.LinkText("Как сделать заказ"));
            var logo = driver.FindElement(By.CssSelector("span.b-ymmain-title-e-name img"));
            var menu = driver.FindElements(By.CssSelector(".b-header-b-menu-e-list li"));
            var select = driver.FindElement(By.CssSelector("select[name='theme']"));
            var option = driver.FindElement(By.CssSelector("select option[value='4']"));
            var notDiscount = driver.FindElement(By.CssSelector("div.product-padding:not(.action-label__text)"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver = null;
        }
    }
}
