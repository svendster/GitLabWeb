using OpenQA.Selenium;

namespace PrimeService.Tests.Pom
{
    public class SearchResultPage:Page
    {
        protected override string Url => "https://demo.nopcommerce.com/search";
        protected override string PageTitle => "nopCommerce demo store. Search";
        protected override By PageCaptionLocator => By.XPath("//div[@class='page-title']/h1");
        protected override string PageCaptionText => "zzzzzzzzzzzzzzzzzzzzzzz";


        public SearchResultPage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}