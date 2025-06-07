using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SauceDemoAutomation.Pages
{
    // Page Object Model class for the Cart Page
    public class CartPage
    {
        private readonly IWebDriver driver;

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;

            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".inventory_item_name")]
        private IList<IWebElement> cartItems;
        [FindsBy(How = How.Id, Using = "checkout")]
        private IWebElement checkout;

        public IList<IWebElement> GetCartItems()
        {
            return cartItems;
        }

        public void GetCheckout()
        {
            checkout.Click();
        }
    }
}
