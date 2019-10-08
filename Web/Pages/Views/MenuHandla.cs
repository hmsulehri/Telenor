using System;
using OpenQA.Selenium;

namespace Web.Pages.Views
{
    public class MenuHandla : PageBase
    {
        private readonly IWebDriver driver;

        public MenuHandla(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public IWebElement MenuContainer => driver.FindElement(By.CssSelector("#subsection_1"));
        public IWebElement HrefBroadband => driver.FindElement(By.CssSelector("#subsection_1 > div > div:nth-child(4) > a"));

        public Boolean IsDisplayed()
        {
            return MenuContainer.Displayed;
        }

        public void ClickOnBroadband()
        {
            HrefBroadband.Click();
        }
    }
}
