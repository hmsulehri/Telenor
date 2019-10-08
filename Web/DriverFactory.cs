using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Runtime.CompilerServices;

namespace Web
{
    public class DriverFactory
    {
        private static readonly ThreadLocal<IWebDriver> tlDriver = new ThreadLocal<IWebDriver>();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void SetDriver(Browser browser)
        {
            switch (browser)
            {
                case Browser.Firefox:
                    FirefoxOptions firefoxOpts = new FirefoxOptions();
                    tlDriver.Value = new FirefoxDriver(firefoxOpts);
                    break;

                case Browser.Chrome:
                    ChromeOptions chromeOpts = new ChromeOptions();
                    tlDriver.Value = new ChromeDriver(chromeOpts);
                    break;
                default:
                    throw new Exception("Browser isn't supported.");
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IWebDriver getDriver()
        {
            return tlDriver.Value;
        }
    }
}
