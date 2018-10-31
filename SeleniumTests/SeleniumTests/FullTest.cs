using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class FullTest
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
        public void MyFullTest()
        {
            //Тест с селектором
            driver.Navigate().GoToUrl("https://www.labirint.ru/guestbook/");

            var writeMessage = driver.FindElement(By.CssSelector("#aone"));
            var name = driver.FindElement(By.CssSelector("input[name='name']"));
            var email = driver.FindElement(By.CssSelector("input[name='email']"));
            var checkbox = driver.FindElement(By.CssSelector("#send_answer"));
            var theme = driver.FindElement(By.CssSelector("select[name='theme']"));
            var message = driver.FindElement(By.CssSelector("#guesttextarea"));
            var send = driver.FindElement(By.CssSelector("input[value='Отправить']"));

            //Основной тест
            driver.Navigate().GoToUrl("https://www.labirint.ru");

            var menu = driver.FindElement(By.CssSelector("[data-toggle='header - genres']"));
            var allBooks = driver.FindElement(By.CssSelector(".b-menu-second-container [href='/books/']"));
            var firstBookButton = driver.FindElement(By.CssSelector(".btn buy-link btn-primary"));
            var buyButton = driver.FindElement(By.CssSelector("btn buy-link btn-primary btn-more"));
            var startBuy = driver.FindElement(By.CssSelector("#basket-default-begin-order"));
            var courier = driver.FindElement(By.CssSelector("label[class*='b-radio-delivery-courier']"));
            var city = driver.FindElement(By.CssSelector("input[data-suggeststype='district']"));
            var validateCity = driver.FindElement(By.CssSelector("#formvalidate-label_jsdistrict_84"));
            var street = driver.FindElement(By.CssSelector("input[data-suggeststype='streets']"));
            var house = driver.FindElement(By.CssSelector("#_jsbuilding_84"));
            var housing = driver.FindElement(By.CssSelector("#b-dlform-m-272-clone [name='corp[272]']"));
            var apartment = driver.FindElement(By.CssSelector("#b-dlform-m-272-clone [name='flat[272]']"));
            var code = driver.FindElement(By.CssSelector("#b-dlform-m-272-clone [name='buildingcode[272]']"));
            var nearDay = driver.FindElement(By.CssSelector(".ui-datepicker-week-hol"));
            var done = driver.FindElement(By.CssSelector("[value='Готово']"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver = null;
        }
    }
}