using System;
using OpenQA.Selenium;

namespace Web.Pages.Views
{
    public class AcceptCookiesPopup : PageBase
    {
        private readonly IWebDriver driver;

        public AcceptCookiesPopup(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public Boolean IsDisplayed() {
            return WaitUntilElementVisible(By.CssSelector("div.cookie-consent-modal"), 10);
        }

        public void AcceptCookies() {
            var btnAcceptCookies = driver.FindElement(By.CssSelector("div.cookie-consent-modal__footer > button"));
            btnAcceptCookies.Click();
        }
    }
}
