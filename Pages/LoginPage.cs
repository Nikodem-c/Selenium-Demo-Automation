using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SauceDemoAutomation.Pages
{
    // Page Object Model class for the Login Page
    public class LoginPage
    {
        private readonly IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "user-name")]
        private IWebElement username;
        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement password;
        [FindsBy(How = How.ClassName, Using = "submit-button")]
        private IWebElement loginButton;

        // Logs into the application using provided credentials
        public ProductsPage Login(string user, string pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            loginButton.Click();
            return new ProductsPage(driver);
        }
    }
}