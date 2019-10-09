using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Collections.Generic;

namespace Web.Pages
{
    public class BroadbandPage : PageBase
    {
        private readonly IWebDriver driver;

        public BroadbandPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        private IWebElement InputAddress => driver.FindElement(By.CssSelector("#Address"));

        public void ScrollToAddress() {
            Actions actions = new Actions(driver);
            actions.MoveToElement(InputAddress);
        }

        public void WriteAddress(string address)
        {
            InputAddress.Clear();
            InputAddress.SendKeys(address);
        }

        public void SelectAddressFromList()
        {
            WaitUntilElementVisible(By.CssSelector("div.address-search-field__autocomplete__list>ul"), 2);
            WaitUntilElementVisible(By.CssSelector("div.address-search-field__autocomplete__list>ul>li:nth-child(1)"), 2);
            ElementClicked(By.CssSelector("div.address-search-field__autocomplete__list>ul>li:nth-child(1)"));
        }

        public void SelectLghFromList()
        {
            if(WaitUntilElementVisible(By.CssSelector(".dropdown-form-field__dropdown"), 2))
            {
                var dropDown = driver.FindElement(By.CssSelector(".dropdown-form-field__dropdown"));
                dropDown.Click();
                dropDown.FindElement(By.CssSelector("option:nth-child(2)")).Click();
            }

            WaitUntilElementVisible(By.CssSelector(".offers-address-search-result__access-types__access-type__products.trailer"), 2);
            IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.CssSelector(".offers-address-search-result__access-types__access-type__products.trailer > div button"));
            Assert.IsTrue(elements.Count > 0);
        }


    }
}
