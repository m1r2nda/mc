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
    public class Pages
    {
        private AllBooksPage allBooks = new AllBooksPage();
        private CourierDeliveryPage courierDelivery = new CourierDeliveryPage();

        public void AddBook()
        {
            allBooks.OpenPage();
            allBooks.AddBook();
            allBooks.RegBook();
        }

        public void CourierDelivery()
        {
            courierDelivery.AddCityAndAssert();
            courierDelivery.AddAddress();
            courierDelivery.FinishRegOrder();
        }
    }
}
