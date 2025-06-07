using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using SauceDemoAutomation.Pages;
using SauceDemoAutomation.Utilities;

namespace SauceDemoAutomation.Tests
{
    // End-to-end test class inheriting from Base class (browser setup/teardown)
    internal class End2End : Base
    {
        [Test, TestCaseSource(nameof(GetTestData)), Category("End2End")]
        public void EndToEnd(string username, string password, string[] expectedProducts)
        {
            // Login to the application
            LoginPage loginpage = new LoginPage(GetDriver());
            ProductsPage productsPage = loginpage.Login(username, password);

            // Add expected products to the cart
            IList<IWebElement> products = productsPage.GetProductsList();

            foreach (var item in products)
            {
                if (expectedProducts.Contains(productsPage.GetProductName(item)))
                {
                    item.FindElement(productsPage.GetAddToCartLocator()).Click();
                }
            }

            // Navigate to cart and verify items
            CartPage cartPage = productsPage.GetCart();
            IList<IWebElement> itemsInCart = cartPage.GetCartItems();

            string[] actualProducts = itemsInCart.Select(item => item.Text.Trim()).ToArray();

            // DEBUG: Print expected vs actual
            Console.WriteLine("EXPECTED PRODUCTS:");
            foreach (var expected in expectedProducts)
            {
                Console.WriteLine($"- {expected}");
            }

            Console.WriteLine("ACTUAL PRODUCTS IN CART:");
            foreach (var actual in actualProducts)
            {
                Console.WriteLine($"- {actual}");
            }

            CollectionAssert.AreEquivalent(expectedProducts, actualProducts);
        }
        /// <summary>
        /// Supplies test data (username & password) from external JSON file.
        /// </summary>
        /// <returns>TestCaseData object for NUnit parameterized test</returns>
        public static IEnumerable<TestCaseData> GetTestData()
        {
            yield return new TestCaseData(GetJsonData().ExtractData("standard_user"), GetJsonData().ExtractData("password"), GetJsonData().ExtracDataArray("products"));

        }
    }
}