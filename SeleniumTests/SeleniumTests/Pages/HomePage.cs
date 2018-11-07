using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests.Pages
{
    public class HomePage : SeleniumTestBase
    {
        private string url = "https://www.labirint.ru/";

        //Локаторы
        public static By booksMenu = By.CssSelector("[data-toggle='header-genres']");
        public static By allBooks = By.CssSelector(".b-menu-second-container [href='/books/']");
        public static By addBookInCart = By.CssSelector(".product-padding a.buy-link");
        public static By issueOrder = By.XPath("(//a[contains(@class,'btn')][contains(@class,'buy-link')][contains(@class,'btn-primary')][contains(@class,'btn-more')])[1]");
        public static By beginOrder = By.CssSelector("#basket-default-begin-order");

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(url);
        }

        public BasketPage AddBookToCart()
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

            driver.FindElement(addBookInCart).Click();
            driver.FindElement(issueOrder).Click();
            driver.FindElement(beginOrder).Click();

            return new BasketPage();
        }
    }
}
