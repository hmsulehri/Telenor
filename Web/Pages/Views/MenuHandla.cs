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

        public IWebElement HandlaMenu => driver.FindElement(By.CssSelector("#subsection_1"));
        public IWebElement Bredbandsabonnemang => driver.FindElement(By.CssSelector("#subsection_1>div>div:nth-child(4)>ul>li:nth-child(2)>a"));

        public Boolean IsDisplayed()
        {
            return HandlaMenu.Displayed;
        }

        public void ClickOnBroadband()
        {
            Bredbandsabonnemang.Click();
        }
    }
}
