using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium; 

namespace Web.Tests
{

    [TestFixture(Browser.Chrome)]
    [TestFixture(Browser.Firefox)]
    public class TestBase
    {
        private Browser browser;
        private IWebDriver driver;
        IDictionary<int, IWebDriver> driverMap = new ConcurrentDictionary<int, IWebDriver>();

        public TestBase(Browser browser)
        {
            this.browser = browser;
        }

        [OneTimeSetUp]
        public void Setup()
        {
            DriverFactory.SetDriver(browser);
            driver = DriverFactory.getDriver();
            driverMap.Add(Thread.CurrentThread.ManagedThreadId, driver);
            driver = driverMap[Thread.CurrentThread.ManagedThreadId];

            driver.Navigate().GoToUrl("https://www.telenor.se");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            foreach (var key in driverMap.Keys)
            {
                driverMap[key].Close();
            }
        }
    }
}
