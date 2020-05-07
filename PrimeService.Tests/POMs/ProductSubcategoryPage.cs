using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PrimeService.Tests.Pom
{
    public class ProductSubcategoryPage : Page
    {
        protected override string Url => "https://demo.nopcommerce.com/";
        protected override string PageTitle => "nopCommerce demo store.";
        protected override By PageCaptionLocator => By.XPath("//div[@class='page-title']/h1");

        protected By ByAddToCartButtonDynamic(string keywords)
        {
            return By.XPath($"//div[h2/a[text()='{keywords}']]/div[@class='add-info']/div[@class='buttons']/input[@value='Add to cart']");
        }
        protected By ByAddToWishListButtonDynamic(string keywords)
        {
            return By.XPath($"//div[h2/a[text()='{keywords}']]/div[@class='add-info']/div[@class='buttons']/input[@value='Add to wishlist']");
        }


        public ProductSubcategoryPage(IWebDriver webDriver,  string keyword)
        {
            TextInfo ti = new CultureInfo("en-US", false).TextInfo;
            Driver = webDriver;
            Url = $"{Url}{FixKeywordForUrlAssertion(keyword)}";
            PageTitle = $"{PageTitle} {FixKeywordsForPageTitleAssertion(keyword)}";
            PageCaptionText = FixKeywordForUrlAssertion(keyword);
        }

        public ProductDetailPage ClickAddToCartDynamic(string keywords, TimeSpan? time=null)
        {
            Driver.FindElement(ByAddToCartButtonDynamic(keywords)).Click();

            //Wait for the "The product has been added to your shopping cart" toast & close it.
            WebDriverWait wait1 = new WebDriverWait(Driver, time ?? DefaultExpectedWaitTime);
            wait1.Until(ExpectedConditions.ElementIsVisible(ByProductAddedToShoppingCartToast));
            Driver.FindElement(ByProductAddedToShoppingCartToastCloseButton).Click();
            WebDriverWait wait2 = new WebDriverWait(Driver, time ?? DefaultExpectedWaitTime);
            wait2.Until(ExpectedConditions.InvisibilityOfElementLocated(ByProductAddedToShoppingCartToast));

            //WebDriverWait wait2 = new WebDriverWait(Driver, time ?? DefaultExpectedWaitTime);
            //wait2.Until(ExpectedConditions.ElementIsVisible(ByAddToCartButtonDynamic(keywords)));

            return new ProductDetailPage(Driver, keywords);
        }

        public ProductDetailPage ClickAddToWishList(string keywords, TimeSpan? time = null)
        {
            Driver.FindElement(ByAddToWishListButtonDynamic(keywords)).Click();

            //Wait for the "The product has been added to your shopping cart" toast & close it.
            WebDriverWait wait1 = new WebDriverWait(Driver, time ?? DefaultExpectedWaitTime);
            wait1.Until(ExpectedConditions.ElementIsVisible(ByProductAddedToShoppingCartToast));
            Driver.FindElement(ByProductAddedToShoppingCartToastCloseButton).Click();
            WebDriverWait wait2 = new WebDriverWait(Driver, time ?? DefaultExpectedWaitTime);
            wait2.Until(ExpectedConditions.InvisibilityOfElementLocated(ByProductAddedToShoppingCartToast));

            //WebDriverWait wait2 = new WebDriverWait(Driver, time ?? DefaultExpectedWaitTime);
            //wait2.Until(ExpectedConditions.ElementIsVisible(ByAddToCartButtonDynamic(keywords)));

            return new ProductDetailPage(Driver, keywords);
        }
    }
}