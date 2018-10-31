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
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized"); // браузер раскрывается на весь экран
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void MyFirstSelect()
        {
            //Переходим на страницу Лабиринта "Вопрос-ответ"
            driver.Navigate().GoToUrl("https://www.labirint.ru/guestbook/");

            //Кликаем "Оставить сообщение"
            var writeMessage = driver.FindElement(By.CssSelector("#aone"));
            writeMessage.Click();

            //В поле "Имя" вводим свое имя
            var name = driver.FindElement(By.CssSelector("#a_writer input[name='name']"));
            name.SendKeys("Тестовое имя");

            //В поле "E-mail" вводим e-mail
            var email = driver.FindElement(By.CssSelector("input[name='email']"));
            email.SendKeys("test@test.ru");

            // В поле с сообщением вводим текст
            var message = driver.FindElement(By.CssSelector("#guesttextarea"));
            message.SendKeys("Простой вопрос");

            //В селекте выбираем тему вопроса двумя разными способами
            var themeElement = driver.FindElement(By.Name("theme"));
            var themeSelector = new SelectElement(themeElement);
            themeSelector.SelectByText("Конкурс");
            themeSelector.SelectByIndex(7);

            Assert.AreEqual("Приложение", themeSelector.SelectedOption.Text.Trim(), "Неверно выбран элемент на странице в теме");
        }

        [Test]
        public void MySecondSelect()
        {
            driver.Navigate().GoToUrl("https://www.metric-conversions.org/ru/length/feet-to-yards.htm");
            (driver as IJavaScriptExecutor).ExecuteScript("$(\"#incs\")[0].selectedIndex=1");
            (driver as IJavaScriptExecutor).ExecuteScript("$(\"#incs\")[0].dispatchEvent(new Event(\"change\"))");
        }

        [Test]
        public void MyFirstCalendar()
        {
            driver.Navigate().GoToUrl("https://www.labirint.ru/books/");
            driver.FindElement(By.XPath("(//*[contains(@class,'product')]//a[contains(@class,'buy-link')])[1]")).Click();
            driver.Navigate().GoToUrl("https://www.labirint.ru/cart/checkout/");
            driver.FindElement(By.Id("basket-default-begin-order")).Click();
            driver.FindElement(By.XPath("//*[contains(@data-gaid,'cart_dlcourier')]")).Click();
            (driver as IJavaScriptExecutor).ExecuteScript($"$('.js-delivery-date').datepicker('setDate','{DateTime.Today.AddDays(8).ToString("dd.MM.yyyy")}')");
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
