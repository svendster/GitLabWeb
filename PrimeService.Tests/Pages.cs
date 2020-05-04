using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras;
using SeleniumExtras.WaitHelpers;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace PrimeService.Tests
{
    public class Pages
    {
        public Pages(Browsers browser)
        {
            _browser = browser;
        }
        Browsers _browser { get; }
        private T GetPages<T>() where T : new()
        {
            var page = (T)Activator.CreateInstance(typeof(T), _browser.getDriver);
            PageFactory.InitElements(_browser.getDriver, page);
            return page;
        }
        public Home Home => GetPages<Home>();
        public Computers Computers => GetPages<Computers>();
    }

}