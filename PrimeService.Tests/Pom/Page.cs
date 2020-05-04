using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeService.Tests.Pom
{
    public abstract class Page
    {
        protected IWebDriver Driver;
        protected virtual string PageUrl { get; }
        protected virtual string PageTitle { get; }

        public void NavigateTo()
        {

        }

        // ### HEADER TOP ROW ###
        protected By byHeaderCurrencyDropdown(IWebDriver driver) => By.Id("customerCurrency");
        protected By byHeaderRegisterLink(IWebDriver driver) => By.CssSelector("ico-register");
        protected By byHeaderLoginLink(IWebDriver driver) => By.CssSelector("ico-login");
        protected By byHeaderWishlistLink(IWebDriver driver) => By.CssSelector("ico-wishlist");
        protected By byHeaderWishlistLabel(IWebDriver driver) => By.CssSelector("wishlist-label");
        protected By byHeaderWishlistQuantity(IWebDriver driver) => By.CssSelector("wishlist-qty");
        protected By byHeaderCartLink(IWebDriver driver) => By.CssSelector("ico-cart");
        protected By byHeaderCartLabel(IWebDriver driver) => By.CssSelector("cart-label");
        protected By byHeaderCartQuantity(IWebDriver driver) => By.CssSelector("cart-qty");
        protected By byHeaderCartButton(IWebDriver driver) => By.CssSelector("button-1 cart-button");

        protected void ClickHeaderCurrencyDropdown(IWebDriver driver) => driver.FindElement(byHeaderCurrencyDropdown(driver)).Click();
        protected void ClickHeaderRegisterLink(IWebDriver driver) => driver.FindElement(byHeaderRegisterLink(driver)).Click();
        protected void ClickHeaderCartLabel(IWebDriver driver) => driver.FindElement(byHeaderCartLabel(driver)).Click();
        protected void ClickHeaderLoginLink(IWebDriver driver) => driver.FindElement(byHeaderLoginLink(driver)).Click();
        protected void ClickHeaderWishlistLink(IWebDriver driver) => driver.FindElement(byHeaderWishlistLink(driver)).Click();
        protected void ClickHeaderWishlistLabel(IWebDriver driver) => driver.FindElement(byHeaderWishlistLabel(driver)).Click();
        protected void ClickHeaderWishlistQuantity(IWebDriver driver) => driver.FindElement(byHeaderWishlistQuantity(driver)).Click();
        protected void ClickHeaderCartLink(IWebDriver driver) => driver.FindElement(byHeaderCartLink(driver)).Click();
        protected void ClickHeaderCartQuantity(IWebDriver driver) => driver.FindElement(byHeaderCartQuantity(driver)).Click();

        // ### HEADER MIDDLE ROW ###
        protected By byHeaderLogo(IWebDriver driver) => By.CssSelector("header-logo");
        protected By byHeaderSearchStoreTextbox(IWebDriver driver) => By.Id("small-searchterms");
        protected By byHeaderSearchStoreButton(IWebDriver driver) => By.CssSelector("button-1 search-box-button");
        protected void ClickHeaderLogo(IWebDriver driver) => driver.FindElement(byHeaderLogo(driver)).Click();
        protected void EnterTextHeaderSearchStoreTextbox(IWebDriver driver, string s) => driver.FindElement(byHeaderSearchStoreTextbox(driver)).SendKeys(s);
        protected void ClickHeaderSearchStoreButton(IWebDriver driver) => driver.FindElement(byHeaderSearchStoreButton(driver)).Click();


        // ### HEADER BOTTOM ROW - SECTIONS ###
        // SECTIONS
        protected By byHeaderSectionComputers(IWebDriver driver) => By.XPath("//a[@href='/computers']");
        protected By byHeaderSectionElectronics(IWebDriver driver) => By.XPath("//a[@href='/electronics']");
        protected By byHeaderSectionApparel(IWebDriver driver) => By.XPath("//a[@href='/apparel']");
        protected By byHeaderSectionDigitalDownloads(IWebDriver driver) => By.XPath("//a[@href='/digital-downloads']");
        protected By byHeaderSectionBooks(IWebDriver driver) => By.XPath("//a[@href='/books']");
        protected By byHeaderSectionJewelry(IWebDriver driver) => By.XPath("//a[@href='/jewelry']");
        protected By byHeaderSectionGiftCards(IWebDriver driver) => By.XPath("//a[@href='/gift-cards']");


        protected void ClickHeaderSectionComputers(IWebDriver driver) => driver.FindElement(byHeaderSectionComputers(driver)).Click();
        protected void ClickHeaderSectionElectronics(IWebDriver driver) => driver.FindElement(byHeaderSectionElectronics(driver)).Click();
        protected void ClickHeaderSectionApparel(IWebDriver driver) => driver.FindElement(byHeaderSectionApparel(driver)).Click();
        protected void ClickHeaderSectionDigitalDownloads(IWebDriver driver) => driver.FindElement(byHeaderSectionDigitalDownloads(driver)).Click();
        protected void ClickHeaderSectionBooks(IWebDriver driver) => driver.FindElement(byHeaderSectionBooks(driver)).Click();
        protected void ClickHeaderSectionJewelry(IWebDriver driver) => driver.FindElement(byHeaderSectionJewelry(driver)).Click();
        protected void ClickHeaderSectionGiftCards(IWebDriver driver) => driver.FindElement(byHeaderSectionGiftCards(driver)).Click();

        //### HEADER BOTTOM ROW - SUBSECTIONS ###
        //Computers
        protected By byHeaderSubsectionDesktops(IWebDriver driver) => By.XPath("//a[@href='/desktops']");
        protected By byHeaderSubsectionLaptops(IWebDriver driver) => By.XPath("//a[@href='/laptops']");
        protected By byHeaderSubsectionSoftware(IWebDriver driver) => By.XPath("//a[@href='/software']");

        protected void ClickHeaderSubsectionDesktops(IWebDriver driver) => driver.FindElement(byHeaderSubsectionDesktops(driver)).Click();
        protected void ClickHeaderSubsectionLaptops(IWebDriver driver) => driver.FindElement(byHeaderSubsectionLaptops(driver)).Click();
        protected void ClickHeaderSubsectionSoftware(IWebDriver driver) => driver.FindElement(byHeaderSubsectionSoftware(driver)).Click();

        //Electronics
        protected By byHeaderSubsectionCameraPhoto(IWebDriver driver) => By.XPath("//a[@href='/camera-photo']");
        protected void ClickHeaderSubsectionCameraPhoto(IWebDriver driver) => driver.FindElement(byHeaderSubsectionCameraPhoto(driver)).Click();

        
        // ...
        //Apparel
        //...
        //Digital Downloads
        //...
        //Books
        //...
        //Jewelry
        //...
        //Gift Cards
        //...


        // ## FOOTER ###
        protected By byFooterSiteMap() => By.XPath("//a[@href='/sitemap']");
        protected By byFooterShippingReturns() => By.XPath("//a[@href='/shipping-returns']");

        protected void ClickFooterSiteMap(IWebDriver driver) => driver.FindElement(byFooterSiteMap()).Click();
        protected void ClickFooterShippingReturns(IWebDriver driver) => driver.FindElement(byFooterShippingReturns()).Click();

        //...
        //...




    }
}
