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
    public class FullTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized"); // браузер раскрывается на весь экран
            driver = new ChromeDriver(options);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void MyFullTest()
        {
            //Основной тест
            driver.Navigate().GoToUrl("https://www.labirint.ru");

            //Наводим на пункт меню либо через Actions либо через API http://jqueryui.com/menu/
            new Actions(driver)
                .MoveToElement(driver.FindElement(By.CssSelector("[data-toggle='header-genres']")))
                .Build()
                .Perform();

            //Ждем, когда элемент подменю появится и наводим на него и кликаем по "Все книги"
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".b-menu-second-container [href='/books/']")));
            new Actions(driver)
                .MoveToElement(driver.FindElement(By.CssSelector(".b-menu-second-container [href='/books/']")))
                .Click()
                .Build()
                .Perform();

            //Кликаем у первой книги по кнопке "В корзину"
            driver.FindElement(By.CssSelector(".product-padding a.buy-link")).Click();

            //Кликаем у первой книги по кнопке "Оформить"
            //driver.FindElement(By.XPath("(//a[contains(@class,'btn')][contains(@class,'buy-link')][contains(@class,'btn-primary')][contains(@class,'btn-more')])[1]")).Click();
            driver.FindElement(By.CssSelector(".product-buy-margin a.buy-link")).Click();//по такому локатору все ок в режиме дебагера, потому что времени не хватает, 
            //здесь можно добавить ожидалку, чтоб ее как раз пройти

            //Кликаем по кнопке "Начать оформление"
            driver.FindElement(By.CssSelector("#basket-default-begin-order")).Click();

            //Выбираем курьерскую доставку
            driver.FindElement(By.CssSelector("[data-gaid='cart_dlcourier']")).Click();

            //Вводим город некорректный
            driver.FindElement(By.CssSelector("input[data-suggeststype='district']")).SendKeys("saasdfsdfsdfdffds");

            //Убираем фокус с поля, например, кликаем Tab
            driver.FindElement(By.CssSelector("input[data-suggeststype='district']")).SendKeys(Keys.Tab);

            //Проверяем, что отобразилась ошибка
            Assert.IsTrue(driver.FindElement(By.CssSelector("span.b-form-error")).Displayed, "Не появилась ошибка о неизвестном городе");

            //Очищаем поле ввода и вводим город корректный
            driver.FindElement(By.CssSelector("input[data-suggeststype='district']")).Clear();
            driver.FindElement(By.CssSelector("input[data-suggeststype='district']")).SendKeys("Екатеринбург");
            driver.FindElement(By.CssSelector("input[data-suggeststype='district']")).SendKeys(Keys.Enter);

            //Вводим название улицы

            //Упадет так как поле неинтерактивное, так как их всего два таких на странице и первое поле не то
            //driver.FindElement(By.CssSelector("input[data-suggeststype='streets']")).SendKeys("Ленина");
            driver.FindElement(By.CssSelector(".js-dlform-wrap input[data-suggeststype='streets']")).SendKeys("Ленина");
            
            //Вводим номер дома
            driver.FindElement(By.CssSelector(".js-dlform-wrap [name^=building]")).SendKeys("1");

            //Вводим номер квартиры
            driver.FindElement(By.CssSelector(".js-dlform-wrap [name^=flat]")).SendKeys("1");

            //Указываем день доставки
            (driver as IJavaScriptExecutor).ExecuteScript($"$('.js-dlform-wrap .js-delivery-date').datepicker('setDate','{DateTime.Today.AddDays(8).ToString("dd.MM.yyyy")}')");

            //И кликаем по кнопке "Готово"
            driver.FindElement(By.CssSelector(".js-dlform-wrap [value=Готово]")).Click();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver = null;
        }
    }
}