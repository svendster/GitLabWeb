using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PrimeService.Tests.Pom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeService.Tests.Pom
{
    public class Homepage: Page
    {
        protected override string Url => "https://demo.nopcommerce.com/";
        protected override string PageTitle => "nopCommerce demo store";
        protected override By PageCaptionLocator => By.XPath("//div[@class='topic-block-title']/h2");
        protected override string PageCaptionText => "Welcome to our store";

        public Homepage(IWebDriver driver)
        {
            Driver = driver;
            Driver.Manage().Cookies.DeleteAllCookies();
        }


    }
}
