using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumTests
{
    class CourierDeliveryPage : SeleniumTestBase
    {
        public static By courier = By.CssSelector("[data-gaid='cart_dlcourier']");
        public static By city = By.CssSelector("input[data-suggeststype='district']");
        public static By cityError = By.CssSelector("span.b-form-error");
        public static By street = By.CssSelector(".js-dlform-wrap input[data-suggeststype='streets']");
        public static By building = By.CssSelector(".js-dlform-wrap [name^=building]");
        public static By flat = By.CssSelector(".js-dlform-wrap [name^=flat]");
        public static By done = By.CssSelector(".js-dlform-wrap [value=Готово]");

        public void AddCityAndAssert()
        {
            driver.FindElement(courier).Click();
            driver.FindElement(city).SendKeys("saasdfsdfsdfdffds");
            driver.FindElement(city).SendKeys(Keys.Enter);
            Assert.IsTrue(driver.FindElement(cityError).Displayed, "Не появилась ошибка о неизвестном городе");

            driver.FindElement(city).Clear();
            driver.FindElement(city).SendKeys("Екатеринбург");
            driver.FindElement(city).SendKeys(Keys.Enter);
        }

        public void AddAddress()
        {
            driver.FindElement(street).SendKeys("Ленина");
            driver.FindElement(building).SendKeys("1");
            driver.FindElement(flat).SendKeys("1");
        }

        public void FinishRegOrder()
        {
            (driver as IJavaScriptExecutor).ExecuteScript($"$('.js-dlform-wrap .js-delivery-date').datepicker('setDate','{DateTime.Today.AddDays(8).ToString("dd.MM.yyyy")}')");
            driver.FindElement(done).Click();
        }

    }
}
