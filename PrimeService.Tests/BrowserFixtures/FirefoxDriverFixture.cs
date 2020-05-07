using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace PrimeService.Tests
{
    public sealed class FirefoxDriverFixture:IDisposable
    {
        public IWebDriver Driver { get; private set; }

        public FirefoxDriverFixture()
        {
            Driver = new FirefoxDriver();
        }

        public void Dispose()
        {
            Driver.Dispose();
        }
    }
}
