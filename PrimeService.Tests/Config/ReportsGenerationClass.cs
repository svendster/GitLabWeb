// https://medium.com/@djhablog/selenium-with-nunit-extentreports-df8ac63acb2c

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace PrimeService.Tests
{
    [SetUpFixture]
    public abstract class ReportsGenerationClass
    {
        protected AventStack.ExtentReports.ExtentReports _extent;
        protected ExtentTest _test;
        public IWebDriver _driver;
        [OneTimeSetUp]
        protected void Setup()
        {
            // NOTE
            // System.Reflection.Assembly.GetCallingAssembly().CodeBase is returning very different paths between DotNetCore 2.1 and 3.1.
            // 2.1 returns "file:///C:/Microsoft/Xamarin/NuGet/nunit/3.12.0/lib/netstandard2.0/nunit.framework.dll"  (breaks path code below)
            // 3.1 returns "file:///C:/GitDesktop/GitLabWeb/PrimeService.Tests/bin/Debug/netcoreapp3.1/nunit.framework.dll" (works)
            // But the current GitLab pipeline requires 2.1, which means that the pipeline will fail if I enable reporting.

            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase; //Doesn't give right path w DotNet Core 2.1
            //var path = typeof(ReportsGenerationClass).Assembly.CodeBase; //Works with 2.1 but then we have issues with Chrome later.
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));

            var projectPath = new Uri(actualPath).LocalPath; 
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
            var reportPath = projectPath + "Reports\\ExtentReport.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            _extent = new AventStack.ExtentReports.ExtentReports();
            _extent.AttachReporter(htmlReporter);
            _extent.AddSystemInfo("Host Name", "LocalHost");
            _extent.AddSystemInfo("Environment", "QA");
            _extent.AddSystemInfo("UserName", "TestUser");
        }
        [OneTimeTearDown]
        protected void TearDown()
        {
            _extent.Flush();
        }
        [SetUp]
        public void BeforeTest()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            _driver.Manage().Window.Maximize();
            _driver.Manage().Cookies.DeleteAllCookies();
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                ? ""
                : TestContext.CurrentContext.Result.StackTrace;
            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    DateTime time = DateTime.Now;
                    String fileName = "Screenshot_" +time.ToString("h_mm_ss") + ".png";
                    String screenShotPath = Capture(_driver, fileName);
                    _test.Log(Status.Fail, "Fail");
                    _test.Log(Status.Fail, "Snapshot below: " +_test.AddScreenCaptureFromPath("Screenshots\\" +fileName));
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
            _test.Log(logstatus, "Test ended with " +logstatus + stacktrace);
            _extent.Flush();
            _driver.Quit();
        }
        public IWebDriver GetDriver()
        {
            return _driver;
        }
        public static string Capture(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            var pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            //var pth = typeof(ReportsGenerationClass).Assembly.CodeBase;
            var actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            var reportPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(reportPath + "Reports\\" + "Screenshots");
            var finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Reports\\Screenshots\\" +screenShotName;
            var localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return reportPath;
        }
    }
}
