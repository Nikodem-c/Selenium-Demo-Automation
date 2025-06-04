using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace SauceDemoAutomation.Pages
{
    // Page Object Model class for the Products Page
    public class ProductsPage
    {
        private readonly IWebDriver driver;
        By productName = By.CssSelector(".inventory_item_name");
        By addToCart = By.XPath(".//button[text()='Add to cart']");
        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            WaitForProductsPage();
        }

        [FindsBy(How = How.ClassName, Using = "inventory_item")]
        private IList<IWebElement> productsList;
        [FindsBy(How = How.ClassName, Using = "shopping_cart_link")]
        private IWebElement cart;

        // Waits until element from the Products Page is visible
        public void WaitForProductsPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("shopping_cart_link")));
        }

        public IList<IWebElement> GetProductsList()
        {
            return productsList;
        }

        public string GetProductName(IWebElement productItem)
        {
            return productItem.FindElement(productName).Text;
        }

        public By GetAddToCartLocator()
        {
            return addToCart;
        }

        public CartPage GetCart()
        {
            cart.Click();
            return new CartPage(driver);
        }
    }
}
