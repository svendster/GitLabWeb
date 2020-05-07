using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeService.Tests.Pom
{
    public class ShoppingCartPage:Page
    {
        protected override string Url => "https://demo.nopcommerce.com/cart";
        protected override string PageTitle => "nopCommerce demo store. Shopping Cart";
        protected override By PageCaptionLocator => By.XPath("//div[@class='page-title']/h1");
        protected override string PageCaptionText => "Shopping cart";

        protected By ByUpdateShoppingCartButton = By.CssSelector("input#updatecart");

        protected By ByTermsOfServiceCheckbox = By.CssSelector("input#termsofservice");

        protected By BySubTotalAmount = By.CssSelector("tr.order-subtotal>td.cart-total-right>span.value-summary");
        protected By ByTotalAmount = By.CssSelector("tr.order-total>td.cart-total-right>span.value-summary");
        protected By ByCheckoutButton = By.CssSelector("button#checkout");

        public ShoppingCartPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void ClickUpdateShoppingCartButton()
        {
            Driver.FindElement(ByUpdateShoppingCartButton).Click();
        }

        public void ClickTermsOfServiceCheckbox()
        {
            Driver.FindElement(ByTermsOfServiceCheckbox).Click();
        }

        public string GetShoppingCartSubtotal()
        {
            return Driver.FindElement(BySubTotalAmount).Text;
        }

        public string GetShoppingCartTotal()
        {
            return Driver.FindElement(ByTotalAmount).Text;
        }

        public void ClickCheckoutButton()
        {
            Driver.FindElement(ByCheckoutButton).Click();
        }
    }
}
