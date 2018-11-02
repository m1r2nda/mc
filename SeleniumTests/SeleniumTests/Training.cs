using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Training
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
        public void TrainingTest()
        {
            //Тренировочные локаторы
            driver.Navigate().GoToUrl("https://www.labirint.ru");

            var searchLine = By.Id("search-field"); //By.CssSelector("#search-field"); Найти локатор поля поиска, именно поиска, без кнопки Искать
            var leftPresentCoupon = By.ClassName("form-getemail-checkout"); //By.CssSelector(".form-getemail-checkout");//найти локатор блока Вам подарок слева, где есть кнопка Получить купон
            var getCoupon = By.ClassName("getemail-btn");
            var aboutBook = By.CssSelector("#product-about"); //на странице конкретной книги блок Аннотации
            var searchHelp = By.Name("searchformadvanced");//на странице https://www.labirint.ru/help/ найти форму поиска
            var help = By.LinkText("Как сделать заказ");//в подвале
            var partialText = By.PartialLinkText("Если ваша покупка дешевле номинала карты");//на странице https://www.labirint.ru/top/certificates/ найти текст
            var allProducts =
                By.XPath(
                    "(//form[contains(@name, 'form-navisort')]//span[contains(@class, 'sorting-value menu-open')])[1]");//на странице рейтинги кнопка Все товары
            var notDiscount = driver.FindElement(By.CssSelector("div.product-padding:not(.action-label__text)"));//книги без скидок
            var year = By.CssSelector("select[name='year_begin'] >option[value='2017']");//на странице Вопрос ответ в селекте во вкладке Поиск в архиве найти 2017 год в начале периода поиска
            var lefttext = By.CssSelector("a[class^=single-block]");//На странице https://www.labirint.ru/guestbook/ найти все ссылки-заголовки в левом блоке - где способы оплаты и тд
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver = null;
        }
    }
}
