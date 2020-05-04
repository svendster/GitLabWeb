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
    public class Homepage: SiteNavigation
    {
        private IWebDriver driver;



        public Homepage(IWebDriver driver)
        {
            this.driver = driver;

            //this.ClickRegister(driver);
        }
        public void goToPage()
        {
            driver.Navigate().GoToUrl("https://demo.nopcommerce.com/");
        }
        public void goToToggleMenu()
        {
            //driver.FindElement(By.XPath(toggle_menu)).Click();
        }

        public void enterUserName(string text)
        {
            //driver.FindElement(By.XPath(userID)).SendKeys(text);
        }

        public void clickLoginBtn()
        {
            //driver.FindElement(By.XPath(loginBtn)).Click();
        }
        public Boolean verifyDashboard()
        {
            //Boolean res = driver.FindElement(By.XPath(menuDashboard)).Displayed;
            return true;
        }
        public void closeBrowser()
        {
            driver.Quit();
        }
    }
}
