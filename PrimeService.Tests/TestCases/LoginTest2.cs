using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeService.Tests;
using PrimeService.Tests.PageMethods;


namespace PrimeService.Tests.TestCases
{
    [TestFixture]
    public class LoginTest2 : ReportsGenerationClass
    {
        OLDLoginPage loginPage;
        [Test]
        [Category("Login")]
        public void test_validLogin()
        {
            loginPage = new OLDLoginPage(GetDriver());
            loginPage.goToPage();
            loginPage.goToToggleMenu();
            loginPage.goToLoginMenu();
            loginPage.enterUserName("John Doe");
            loginPage.enterPassword("ThisIsNotAPassword");
            loginPage.clickLoginBtn();
            Assert.IsTrue(loginPage.verifyDashboard());
            //loginPage.closeBrowser();
        }
        [Test]
        [Category("Login")]
        public void test_invalidLogin()
        {
            loginPage = new OLDLoginPage(GetDriver());
            loginPage.goToPage();
            loginPage.goToToggleMenu();
            loginPage.goToLoginMenu();
            loginPage.enterUserName("John Doe");
            loginPage.enterPassword("ThisIsNotA");
            loginPage.clickLoginBtn();
            Assert.IsTrue(loginPage.verifyDashboard());
            loginPage.closeBrowser();
        }
    }
}
