using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PrimeService.Tests.Pom
{
    public class ProductDetailPage : Page
    {
        protected override string Url => "https://demo.nopcommerce.com/";
        protected override string PageTitle => "";
        protected override By PageCaptionLocator => By.XPath("//div[@class='overview']/div[@class='product-name']/h1");

        protected By ByAddToCartTextbox = By.XPath("//div[@class='add-to-cart-panel]/input[@class='qty-input valid']");
        protected By ByAddToCartButton = By.XPath("//div[@class='add-to-cart-panel]/input[@value='Add to cart']");

        protected By ByProductWasAddedPopup = By.XPath("//div[@class='bar-notification success']/p/span");

        protected By ByProductPrice = By.XPath("//div[@class='product-price'/span");


        public ProductDetailPage(IWebDriver webDriver, string keyword)
        {
            Driver = webDriver;
            Url = $"{Url}{FixKeywordForUrlAssertion(keyword)}";
            PageTitle = $"{PageTitle} {FixKeywordsForPageTitleAssertion(keyword)}";
            PageCaptionText = FixKeywordForUrlAssertion(keyword);
        }

        public void EnterProductQuantity(int num) => Driver.FindElement(ByAddToCartTextbox).SendKeys(num.ToString());
        public void ClickAddToCart() => Driver.FindElement(ByAddToCartButton).Click();


    }
}