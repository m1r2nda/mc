using System;
using OpenQA.Selenium;

namespace SeleniumTests.Pages
{
    public class CourierDeliveryLightbox : SeleniumTestBase
    {
        public static By city = By.CssSelector("input[data-suggeststype='district']");
        public static By cityError = By.CssSelector("span.b-form-error");
        public static By street = By.CssSelector(".js-dlform-wrap input[data-suggeststype='streets']");
        public static By building = By.CssSelector(".js-dlform-wrap [name^=building]");
        public static By flat = By.CssSelector(".js-dlform-wrap [name^=flat]");
        public static By confirm = By.CssSelector(".js-dlform-wrap [value=Готово]");
        public static By lightbox = By.CssSelector(".js-dlform-wrap");
        public static By suggestedCity = By.CssSelector(".suggests-item-txt");

        public void AddCity(string cityName, bool fromSuggest = true)
        {
            driver.FindElement(city).Clear();
            driver.FindElement(city).SendKeys(cityName);
            if(fromSuggest) { driver.FindElement(suggestedCity).Click(); }
            else driver.FindElement(city).SendKeys(Keys.Enter);
        }

        public string City {
            get { return driver.FindElement(city).Text; }
            set {
                driver.FindElement(city).Clear();
                driver.FindElement(city).SendKeys(value);
                driver.FindElement(city).SendKeys(Keys.Enter);
            }
        }
        
        public void AddAddress(string streetName, string buildingNumber, string flatNumber)
        {
            driver.FindElement(street).SendKeys(streetName);
            driver.FindElement(building).SendKeys(buildingNumber);
            driver.FindElement(flat).SendKeys(flatNumber);
        }

        public void SelectDate()
        {
            (driver as IJavaScriptExecutor).ExecuteScript($"$('.js-dlform-wrap .js-delivery-date').datepicker('setDate','{DateTime.Today.AddDays(8).ToString("dd.MM.yyyy")}')");
        }

        public void Confirm()
        {
            driver.FindElement(confirm).Click();
        }

        public bool IsInvalidCityErrorVisible => driver.FindElement(cityError).Displayed;
        public bool IsVisible => driver.FindElement(lightbox).Displayed;
    }
}
