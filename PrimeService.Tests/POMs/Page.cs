using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
        protected virtual string Url { get; set; }
        protected virtual string PageTitle { get; set; }
        protected virtual string PageCaptionText { get; set; }
        protected virtual By PageCaptionLocator { get; set; }
        protected virtual TimeSpan DefaultExpectedWaitTime => TimeSpan.FromMilliseconds(1500); //default is 1 second

        // ### LOCATORS ###
        #region LOCATORS
        // TOP ROW OF HEADER
        public By ByHeaderCurrencyDropdown = By.Id("customerCurrency");
        public By ByHeaderRegisterLink= By.CssSelector("a.ico-register");
        public By ByHeaderLoginLink = By.CssSelector("a.ico-login");
        public By ByHeaderWishlistLink = By.CssSelector("a.ico-wishlist");
        public By ByHeaderWishlistLabel = By.CssSelector("span.wishlist-label");
        public By ByHeaderWishlistQuantity = By.CssSelector("span.wishlist-qty");
        public By ByHeaderCartLink = By.CssSelector("a.ico-cart");
        public By ByHeaderCartLabel = By.CssSelector("span.cart-label");
        public By ByHeaderCartQuantity = By.CssSelector("span.cart-qty");
        public By ByHeaderCartButton = By.CssSelector("input.button-1.cart-button");
        public By ByProductAddedToShoppingCartToast = By.CssSelector("div.bar-notification.success");
        public By ByProductAddedToShoppingCartToastCloseButton = By.XPath("//div[@class='bar-notification success']/span");

        //bar-notification success
        // MIDDLE ROW OF HEADER
        public By ByHeaderLogo = By.CssSelector("header-logo");
        public By ByHeaderSearchStoreTextbox = By.Id("small-searchterms");
        public By ByHeaderSearchStoreButton = By.CssSelector("button-1 search-box-button");
        // BOTTOM ROW OF HEADER
        public By ByHeaderSectionDynamic(string keyword) => By.XPath($"//ul[@class='top-menu notmobile']//a[contains(., '{keyword}')]");
        public By ByHeaderSubsectionDynamic(string keyword)
        {
            return By.XPath($"//ul[@class='top-menu notmobile']//ul[@class='sublist first-level']//a[contains(., '{FixKeywordsForPageCaptionAssertion(keyword)}')]");
        }

        // FOOTER
        public By ByFooterDynamic(string keyword) => By.XPath($"//a[@href='/{keyword}']");
        public By ByEmailTextBox = By.Id("newsletter-email");
        private object driver;
        #endregion //LOCATORS



        /// <summary>
        /// Pause until page title changes
        /// </summary>
        /// <param name="keywords"></param>
        protected void StandardWaitForPageTitleChange(string keywords, TimeSpan? time=null)
        {
            WebDriverWait wait = new WebDriverWait(Driver, time ?? DefaultExpectedWaitTime);
            wait.Until(ExpectedConditions.ElementExists(By.XPath($"//title[contains(text(),'{FixKeywordsForPageTitleAssertion(keywords)}')]")));
        }

        protected void StandardWaitForElementToExist(string keywords, By by, TimeSpan? time = null)
        {
            WebDriverWait wait = new WebDriverWait(Driver, time ?? DefaultExpectedWaitTime);
            wait.Until(ExpectedConditions.ElementExists(by));
        }

        protected void StandardWaitForElementToBeVisible(By by, TimeSpan? time = null)
        {
            WebDriverWait wait = new WebDriverWait(Driver, time ?? DefaultExpectedWaitTime);
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }


        // ### INHERITED METHODS ###
        #region INHERITED METHODS

        public void GoToPage(bool? checkBeginningOfUrlOnly = true)
        {
            Driver.Navigate().GoToUrl(Url);
            CheckThatRightPageWasLoaded();
        }
  
        /// <summary>
        /// Confirm that the following are correct: URL, title in tab & page caption
        /// </summary>
        /// <param name="checkBeginningOfUrlOnly"></param>
        public void CheckThatRightPageWasLoaded(bool? checkBeginningOfUrlOnly = true)
        {
            bool urlIsRight;

            urlIsRight = ((bool)checkBeginningOfUrlOnly)
                ? Driver.Url.StartsWith(Url)
                : Driver.Url == Url;

            IWebElement pageCaptionElement = Driver.FindElement(PageCaptionLocator);

            bool pageLoadedAsExpected = urlIsRight && Driver.Title.StartsWith(PageTitle) && pageCaptionElement.Text.StartsWith(PageCaptionText);

            //flag unexpected URL
            if (!urlIsRight) throw new Exception($"There was a problem loading the page \"{PageTitle}\" {Url}");

            //flag unexpected page title
            if(!Driver.Title.StartsWith(PageTitle)) throw new Exception($"The page title for {Url} appears to be wrong. Something starting with \"{PageTitle}\" was expected but it was instead \"{Driver.Title}\"");

            //flag unexpected page caption
            if(!pageCaptionElement.Text.StartsWith(FixKeywordsForPageCaptionAssertion(PageCaptionText))) throw new Exception($"The caption on the page title appears to be wrong. Something starting with \"{PageCaptionText}\" was expected but it was instead \"{pageCaptionElement.Text}\"");

        }

        // TOP ROW OF HEADER
        public RegistrationPage ClickHeaderRegisterLink()
        {
            Driver.FindElement(ByHeaderRegisterLink).Click();
            return new RegistrationPage(Driver);
        }

        public void ClickHeaderCartLink() => Driver.FindElement(ByHeaderCartLink).Click();
        public void ClickHeaderCartButton() => Driver.FindElement(ByHeaderCartButton).Click();
        public void ClickHeaderLoginLink() => Driver.FindElement(ByHeaderLoginLink).Click();
        public void ClickHeaderWishlistLink() => Driver.FindElement(ByHeaderWishlistLink).Click();
        public void ClickHeaderWishlistLabel() => Driver.FindElement(ByHeaderWishlistLabel).Click();
        public void ClickHeaderWishlistQuantity() => Driver.FindElement(ByHeaderWishlistQuantity).Click();


        public int GetCartQuantity(TimeSpan? timeSpan=null)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollTo(0, 0);");

            StandardWaitForElementToBeVisible(ByHeaderCartQuantity, timeSpan);

            string val = Driver.FindElement(ByHeaderCartQuantity).Text;
            val = val.Replace("(", "");
            val = val.Replace(")", "");
            return int.Parse(val);
        }

        public int GetWishListQuantity(TimeSpan? timeSpan = null)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollTo(0, 0);");

            StandardWaitForElementToBeVisible(ByHeaderWishlistQuantity, timeSpan);

            string val = Driver.FindElement(ByHeaderWishlistQuantity).Text;
            val = val.Replace("(", "");
            val = val.Replace(")", "");
            return int.Parse(val);
        }

        // MIDDLE ROW OF HEADER
        public void ClickHeaderLogo() => Driver.FindElement(ByHeaderLogo).Click();
        public void ClickHeaderSearchStoreButton() => Driver.FindElement(ByHeaderSearchStoreButton).Click();

        public SearchResultPage SearchForStore(string s)
        {
            Driver.FindElement(ByHeaderSearchStoreTextbox).SendKeys(s);
            Driver.FindElement(ByHeaderSearchStoreButton).Click();
            return new SearchResultPage(Driver);
        }

        public RegistrationPage Register(string s)
        {
            ClickHeaderRegisterLink();
            return new RegistrationPage(Driver);
        }

        public LoginPage Login(string s)
        {
            ClickHeaderLoginLink();
            return new LoginPage(Driver);
        }

        public WishlistPage ViewWishlist(string s)
        {
            ClickHeaderWishlistLink();
            return new WishlistPage(Driver);
        }

        public ShoppingCartPage ViewShoppingCartByClickingLink()
        {
            ClickHeaderCartLink();
            return new ShoppingCartPage(Driver);
        }

        public ShoppingCartPage ViewShoppingCartByHovering()
        {
            IWebElement el = Driver.FindElement(ByHeaderCartLink);
            Actions action = new Actions(Driver);

            action.MoveToElement(el);
            ClickHeaderCartButton();

            return new ShoppingCartPage(Driver);
        }

        public ProductCategoryPage GoToProductCategoryPage(string keyword)
        {
            ClickHeaderSectionDynamic(keyword);
            StandardWaitForPageTitleChange(keyword);
            return new ProductCategoryPage(Driver, keyword);
        }


        //BOTTOM ROW OF HEADER
        public void ClickHeaderSectionDynamic(string keyword) => Driver.FindElement(ByHeaderSectionDynamic(keyword)).Click();
        public void ClickHeaderSubsectionDynamic(string keyword) => Driver.FindElement(ByHeaderSubsectionDynamic(keyword)).Click();
        public void ClickFooterDynamic(string keyword) => Driver.FindElement(ByFooterDynamic(keyword)).Click();

        public string FixKeywordForUrlAssertion(string keywords)
        {
            keywords = keywords.Replace(" & ", " ");
            keywords = keywords.Replace(" ", "-");
            keywords = keywords.ToLower();
            return keywords;
        }

        public string FixKeywordsForPageTitleAssertion(string keywords)
        {
            return keywords.Substring(0, 1).ToUpper() + keywords.Substring(1);
        }


        public string FixKeywordsForPageCaptionAssertion(string keywords)
        {
            return  keywords.Substring(0, 1).ToUpper() + keywords.Substring(1);
        }
      
    

        #endregion // INHERITED METHODS






    }
}
