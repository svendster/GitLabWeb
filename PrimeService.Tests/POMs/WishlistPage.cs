using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeService.Tests.Pom
{
    public class WishlistPage:Page
    {
        protected override string Url => "https://demo.nopcommerce.com/wishlist";
        protected override string PageTitle => "nopCommerce demo store. Wishlist";
        protected override By PageCaptionLocator => By.XPath("//div[@class='page-title']/h1");
        protected override string PageCaptionText => "Wishlist";

        public WishlistPage(IWebDriver driver)
        {
            Driver = driver;
        }

    }
}
