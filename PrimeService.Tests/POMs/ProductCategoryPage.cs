using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PrimeService.Tests.Pom
{
    public class ProductCategoryPage:Page
    {


        protected override string Url => "https://demo.nopcommerce.com/";
        protected override string PageTitle => "nopCommerce demo store.";
        protected override By PageCaptionLocator => By.XPath("//div[@class='page-title']/h1");

        public ProductCategoryPage(IWebDriver webDriver, string keyword)
        {
            Driver = webDriver;
            Url = $"{Url}{FixKeywordForUrlAssertion(keyword)}";
            PageTitle = $"{PageTitle} {FixKeywordsForPageTitleAssertion(keyword)}";
            PageCaptionText = FixKeywordForUrlAssertion(keyword);
        }

        private By BySubcategoryHeaderDynamic(string keyword) => By.XPath($"//h2[@class='title']/a[@title='Show products in category {keyword}']");
        private By BySubcategoryPictureDynamic(string keyword) => By.XPath($"//div[@class='picture']/a[@title='Show products in category {keyword}']");

        protected virtual void ClickSubcategoryHeaderDynamic(string keyword) => Driver.FindElement(BySubcategoryHeaderDynamic(keyword)).Click();
        protected virtual void ClickSubcategoryPictureDynamic(string keyword) => Driver.FindElement(BySubcategoryPictureDynamic(keyword)).Click();

        public ProductSubcategoryPage GetProductSubcategoryPageByHeaderDynamic(string keyword)
        {
            StandardWaitForElementToBeVisible(BySubcategoryHeaderDynamic(keyword), TimeSpan.FromSeconds(1));

            Driver.FindElement(BySubcategoryHeaderDynamic(keyword)).Click();
            
            StandardWaitForPageTitleChange(keyword, TimeSpan.FromSeconds(2));
            
            return new ProductSubcategoryPage(Driver, keyword);
        }


    }
}
