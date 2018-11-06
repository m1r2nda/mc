using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    class AllBooksPage : SeleniumTestBase
    {
        public static By booksMenu = By.CssSelector("[data-toggle='header-genres']");
        public static By allBooks = By.CssSelector(".b-menu-second-container [href='/books/']");
        public static By basket = By.CssSelector(".product-padding a.buy-link");

        public static By issue = By.XPath(
            "(//a[contains(@class,'btn')][contains(@class,'buy-link')][contains(@class,'btn-primary')][contains(@class,'btn-more')])[1]");
        public static By beginOrder = By.CssSelector("#basket-default-begin-order");

        public void AddBook()
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

        public void RegBook()
        {
            driver.FindElement(issue).Click();
            driver.FindElement(beginOrder).Click();
        }
    }
}
