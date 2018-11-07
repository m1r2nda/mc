using OpenQA.Selenium;

namespace SeleniumTests.Pages
{
    public class BasketPage : SeleniumTestBase
    {
        private By chooseCourierDelivery = By.CssSelector("[data-gaid='cart_dlcourier']");

        public void ChooseCourierDelivery()
        {
            driver.FindElement(chooseCourierDelivery).Click();
        }

        public CourierDeliveryLightbox CourierDeliveryLightbox => new CourierDeliveryLightbox();
    }
}
