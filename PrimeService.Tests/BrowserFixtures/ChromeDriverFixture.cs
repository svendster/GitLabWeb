using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PrimeService.Tests
{
    public class ChromeDriverFixture:IDisposable
    {
        public IWebDriver Driver { get; private set; }

        public  ChromeDriverFixture()
        {
            Driver = new ChromeDriver();
        }

        public void Dispose()
        {
            Driver.Dispose();
        }
    }
}
