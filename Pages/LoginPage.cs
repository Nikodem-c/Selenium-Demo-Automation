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
        [FindsBy(How = How.CssSelector, Using = "[data-test='error']")]
        private IWebElement errorMessage;

        //Logs into the application using provided credentials
        public void Login(string user, string pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            loginButton.Click();
        }

        public void AttemptLogin(string user, string pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            loginButton.Click();
        }

        // Checks for user, password, and login button fields
        public bool IsLoginFormVisible()
        {
            return username.Displayed && password.Displayed && loginButton.Displayed;
        }

        public bool HasLoginError()
        {
            return errorMessage.Text.Contains("locked out");
        }

        public bool IsErrorVisible()
        {
            return errorMessage.Displayed;
        }
    }
}