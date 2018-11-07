using NUnit.Framework;
using SeleniumTests.Pages;

namespace SeleniumTests
{
    [TestFixture]
    public class FullTest : SeleniumTestBase
    {
        private HomePage homePage = new HomePage();

        [Test]
        public void BasketPage_EnterIncorrectCity_ErrorWasShown()
        {
            //Arrange
            homePage.OpenPage();
            var basketPage = homePage.AddBookToCart();
            basketPage.ChooseCourierDelivery();

            //Вводим несуществующий город
            basketPage.CourierDeliveryLightbox.AddCity("saasdfsdfsdfdffds", fromSuggest:false);
            
            Assert.IsTrue(basketPage.CourierDeliveryLightbox.IsInvalidCityErrorVisible, "Не появилась ошибка о неизвестном городе");
        }

        [Test]
        public void BasketPage_IssueCourierDelivery_Success()
        {
            //Arrange
            homePage.OpenPage();
            var basketPage = homePage.AddBookToCart();
            basketPage.ChooseCourierDelivery();
            basketPage.CourierDeliveryLightbox.AddCity("Екатеринбург");
            // Альтернативный вариант: basketPage.CourierDeliveryLightbox.City = "Екатеринбург";
            basketPage.CourierDeliveryLightbox.AddAddress("Ленина", "1", "1");
            basketPage.CourierDeliveryLightbox.SelectDate();
            basketPage.CourierDeliveryLightbox.Confirm();

            Assert.IsFalse(basketPage.CourierDeliveryLightbox.IsVisible, "Не скрылся лайтбокс");
        }
    }
}