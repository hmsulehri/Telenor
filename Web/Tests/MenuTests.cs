using NUnit.Framework;
using OpenQA.Selenium;
using Web.Pages;
using Web.Pages.Views;

namespace Web.Tests
{
    [TestFixture(Browser.Chrome)]
    [TestFixture(Browser.Firefox)]
    [Parallelizable(ParallelScope.Fixtures)]
    public class MenuTests : TestBase
    {
        private static readonly string ADDRESS = "Storgatan 1, Uppsala";

        public MenuTests(Browser browser) : base(browser) {}

        [Test]
        public void Test_SearchIfBroadbandAvailableOnAddress()
        {
            IWebDriver driver = DriverFactory.getDriver();

            var cookiesPopup = new AcceptCookiesPopup(driver);
            if (cookiesPopup.IsDisplayed())
                cookiesPopup.AcceptCookies();

            var homePage = new HomePage(driver);
            homePage.ClickOnMenuHandla();

            var handlaMenu = new MenuHandla(driver);
            if (handlaMenu.IsDisplayed())
                handlaMenu.ClickOnBroadband();

            var broadbandPage = new BroadbandPage(driver);
            broadbandPage.ScrollToAddress();
            broadbandPage.WriteAddress(ADDRESS);
            broadbandPage.SelectAddressFromList();
            broadbandPage.SelectLghFromList();
        }
    }
}
