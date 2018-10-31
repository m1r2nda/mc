using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Lecture
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
        public void LectureTest()
        {
            //Selenium получает уникальный id
            //Здесь ищем элемент по имени класса
            driver.Navigate().GoToUrl("https://www.labirint.ru");
            var element = driver.FindElement(By.ClassName("b-header-b-menu-e-text"));
            element.Click();
            //попробуем что-нибудь сделать после обновления страницы и получаем ошибку
            driver.Navigate().Refresh();
            element.Click();
            //Получаем значения свойств
            var property = element.GetAttribute("textContent");
            var attribute = element.GetAttribute("href");
            //получаем значение текста в поле ввода
            var elementSearch = driver.FindElement(By.Id("search-field"));
            var text = elementSearch.Text;
            var value = elementSearch.GetAttribute("placeholder");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver = null;
        }
    }
}
