using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeService.Tests.Pom
{
    public class RegistrationResultsPage:Page
    {


        protected override string PageTitle => "nopCommerce demo store. Register";
        protected override string Url => "https://demo.nopcommerce.com/registerresult";

        protected override By PageCaptionLocator => By.XPath("//div[@class='page-title']/h1");
        protected override string PageCaptionText => "Register";


        protected By ByRegistrationCompleteMessage = By.XPath("//*[text()='Your registration completed']");
        protected By ByContinueAfterRegisterButton = By.CssSelector("input.button-1.register-continue-button");


        public RegistrationResultsPage(IWebDriver driver)
        {
            Driver = driver;
        }

        
        public bool RegistrationIsCompleteMessageWasDisplayed()
        {
            return Driver.FindElement(ByRegistrationCompleteMessage).Displayed;
        }

        public Homepage ClickContinueAfterRegister()
        {
            Driver.FindElement(ByContinueAfterRegisterButton).Click();
            return new Homepage(Driver);
        }
    }
}
