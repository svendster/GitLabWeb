using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PrimeService.Tests.Pom
{
    public class RegistrationPage:Page
    {


        protected override string PageTitle => "nopCommerce demo store. Register";
        protected override string Url => "https://demo.nopcommerce.com/register";

        protected override By PageCaptionLocator => By.XPath("//div[@class='page-title']/h1");
        protected override string PageCaptionText => "Register";


        protected By ByGenderMaleRadioButton = By.CssSelector("input.gender-male");
        protected By ByGenderFemaleRadioButton = By.CssSelector("input.gender-female");
        protected By ByFirstNameTextbox = By.CssSelector("input#FirstName");
        protected By ByLastNameTextbox = By.CssSelector("input#LastName");
        protected By ByEmailTextbox = By.CssSelector("input#Email");
        protected By ByPasswordTextbox = By.CssSelector("input#Password");
        protected By ByConfirmPasswordTextbox = By.CssSelector("input#ConfirmPassword");
        protected By ByRegisterButton = By.CssSelector("input#register-button");


        public RegistrationPage(IWebDriver driver)
        {
            Driver = driver;
        }


        public void Sleep(int? timeSpanInMilliseconds = null)
        {
            Thread.Sleep(timeSpanInMilliseconds ?? 250); 
        }

        public void EnterRegistrationFirstName(string s)
        {
            Driver.FindElement(ByFirstNameTextbox).SendKeys(s);
            Sleep(); //I wouldn't normally do this, but there seems to a bug that requires this.
        }

        public void EnterRegistrationLastName(string s)
        {
            Driver.FindElement(ByLastNameTextbox).SendKeys(s);
            Sleep(); //I wouldn't normally do this, but there seems to a bug that requires this.
        }

        public void EnterRegistrationEmail(string s)
        {
            Driver.FindElement(ByEmailTextbox).SendKeys(s);
            Sleep(); //I wouldn't normally do this, but there seems to a bug that requires this.
        }

        public void EnterRegistrationPassword(string s)
        {
            Driver.FindElement(ByPasswordTextbox).SendKeys(s);
            Driver.FindElement(ByConfirmPasswordTextbox).SendKeys(s);
            Sleep(); //I wouldn't normally do this, but there seems to a bug that requires this.
        }

        public RegistrationResultsPage ClickRegister()
        {
            Driver.FindElement(ByRegisterButton).Click();
            return new RegistrationResultsPage(Driver);
        }
    }
}
