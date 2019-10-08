using NUnit.Framework;
using OpenQA.Selenium;

namespace Web.Pages
{
    public class HomePage : PageBase
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public IWebElement MenuHandla => driver.FindElement(By.CssSelector("div.page-header__nav__main-sections>ul>li:nth-child(2)"));

        public void ClickOnMenuHandla()
        {
            MenuHandla.Click();
        }

        public void VerifyMenuHandlaText()
        {
            Assert.IsTrue(IsElementTextPresent(MenuHandla, By.CssSelector("a"), "Handla"));
        }
    }
}
