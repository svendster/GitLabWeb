using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeService.Tests.Pom
{
    public class LoginPage:Page
    {
        protected override string Url => "https://demo.nopcommerce.com/register";
        protected override string PageTitle => "noCommerce demo store. Login";
        protected override By PageCaptionLocator => By.XPath("//div[@class='page-title']/h1");
        protected override string PageCaptionText => "Welcome, Please Sign In!";

        public LoginPage(IWebDriver driver)
        {
            Driver = driver;
        }

    }
}
