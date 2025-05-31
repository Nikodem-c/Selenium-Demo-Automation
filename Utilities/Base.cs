using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Configuration;

namespace SauceDemoAutomation.Utilities
{
    // Base class for initializing and closing the browser for tests
    internal class Base
    {
        public IWebDriver driver;
        string browserName;

        [SetUp]
        public void Setup()
        {
            // Get browser name from App.config
            if (browserName == null)
            {
                browserName = ConfigurationManager.AppSettings["browser"];
            }
            InitBrowser(browserName);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();

            driver.Url = "https://www.saucedemo.com/";
        }

        // Launch and configure browser based on the provided name 
        public void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());

                    // Disable Chrome's password leak warning popup
                    ChromeOptions options = new ChromeOptions();
                    options.AddUserProfilePreference("profile.password_manager_leak_detection", false);

                    driver = new ChromeDriver(options);
                    break;
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;
                default:
                    throw new ArgumentException($"Unsupported browser: {browserName}");
            }
        }

        // Getter for the WebDriver instance
        public IWebDriver GetDriver()
        {
            return driver;
        }

        public static JsonReader GetJsonData()
        {
            return new JsonReader();
        }

        [TearDown]
        public void TearDown()
        {
            // Close and clean up browser after test
            if (driver != null)
            {
                driver.Close();
                driver.Dispose();
            }
        }
    }
}
