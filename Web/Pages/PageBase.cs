using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Web.Pages
{
    public class PageBase
    {
        private readonly IWebDriver driver;

        public PageBase(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected bool IsElementTextPresent(IWebElement element, By by, string expectedText)
        {
            try
            {
                return element.FindElement(by).Text.Equals(expectedText);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        protected bool IsElementTextPresent(By by, string expectedText)
        {
            try
            {
                return driver.FindElement(by).Text.Equals(expectedText);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        protected bool IsElementPresent(IWebElement element, By by)
        {
            try
            {
                return element.FindElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        protected bool IsElementPresent(By by)
        {
            try
            {
                return driver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        protected bool ElementClicked(IWebElement element, By by)
        {
            try
            {
                element.FindElement(by).Click();
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        protected bool ElementClicked(By by)
        {
            try
            {
                driver.FindElement(by).Click();
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        protected bool WaitUntilElementVisible(By by, double timeout) {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                IWebElement element = wait.Until(d => d.FindElement(by));

                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
