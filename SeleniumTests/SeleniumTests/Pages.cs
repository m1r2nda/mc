using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    public class Pages : SeleniumTestBase
    {
        private By booksMenu = By.CssSelector("[data-toggle='header-genres']");
        private By allBooks = By.CssSelector(".b-menu-second-container [href='/books/']");
        private By basket = By.CssSelector(".product-padding a.buy-link");

        private By issue = By.XPath(
            "(//a[contains(@class,'btn')][contains(@class,'buy-link')][contains(@class,'btn-primary')][contains(@class,'btn-more')])[1]");
        private By beginOrder = By.CssSelector("#basket-default-begin-order");

        private By courier = By.CssSelector("[data-gaid='cart_dlcourier']");
        private By city = By.CssSelector("input[data-suggeststype='district']");
        private By cityError = By.CssSelector("span.b-form-error");
        private By street = By.CssSelector(".js-dlform-wrap input[data-suggeststype='streets']");
        private By building = By.CssSelector(".js-dlform-wrap [name^=building]");
        private By flat = By.CssSelector(".js-dlform-wrap [name^=flat]");
        private By done = By.CssSelector(".js-dlform-wrap [value=Готово]");

        public void AddBookInBasket()
        {
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

        public void RegOrder()
        {
            driver.FindElement(issue).Click();
            driver.FindElement(beginOrder).Click();
        }

        public void CourierDelivery()
        {
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
