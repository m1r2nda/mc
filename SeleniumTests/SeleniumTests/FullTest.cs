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
            driver.Navigate().GoToUrl("https://www.labirint.ru");
            AddBookInBasket();
            RegOrder();
            CourierDelivery();
        }

        private void AddBookInBasket()
        {
            var booksMenu = By.CssSelector("[data-toggle='header-genres']");
            var allBooks = By.CssSelector(".b-menu-second-container [href='/books/']");
            var basket = By.CssSelector(".product-padding a.buy-link");

            //Наводим на пункт меню либо через Actions либо через API http://jqueryui.com/menu/
            new Actions(driver)
                .MoveToElement(driver.FindElement(booksMenu))
                .Build()
                .Perform();

            //Ждем, когда элемент подменю появится и наводим на него и кликаем по "Все книги"
            wait.Until(ExpectedConditions.ElementIsVisible(allBooks));
            new Actions(driver)
                .MoveToElement(driver.FindElement(allBooks))
                .Click()
                .Build()
                .Perform();

            driver.FindElement(basket).Click();
        }

        private void RegOrder()
        {
            var issue = By.XPath(
                "(//a[contains(@class,'btn')][contains(@class,'buy-link')][contains(@class,'btn-primary')][contains(@class,'btn-more')])[1]");
            var beginOrder = By.CssSelector("#basket-default-begin-order");

            driver.FindElement(issue).Click();
            driver.FindElement(beginOrder).Click();
        }
        
        private void CourierDelivery()
        {
            var courier = By.CssSelector("[data-gaid='cart_dlcourier']");
            var city = By.CssSelector("input[data-suggeststype='district']");
            var cityError = By.CssSelector("span.b-form-error");
            var street = By.CssSelector(".js-dlform-wrap input[data-suggeststype='streets']");
            var building = By.CssSelector(".js-dlform-wrap [name^=building]");
            var flat = By.CssSelector(".js-dlform-wrap [name^=flat]");
            var done = By.CssSelector(".js-dlform-wrap [value=Готово]");

            driver.FindElement(courier).Click();
            driver.FindElement(city).SendKeys("saasdfsdfsdfdffds");
            driver.FindElement(city).SendKeys(Keys.Tab);
            Assert.IsTrue(driver.FindElement(cityError).Displayed, "Не появилась ошибка о неизвестном городе");

            driver.FindElement(city).Clear();
            driver.FindElement(city).SendKeys("Екатеринбург");
            driver.FindElement(city).SendKeys(Keys.Enter);

            driver.FindElement(street).SendKeys("Ленина");
            driver.FindElement(building).SendKeys("1");
            driver.FindElement(flat).SendKeys("1");
            (driver as IJavaScriptExecutor).ExecuteScript($"$('.js-dlform-wrap .js-delivery-date').datepicker('setDate','{DateTime.Today.AddDays(8).ToString("dd.MM.yyyy")}')");
            driver.FindElement(done).Click();
        }
    }
}