using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Configuration;

namespace SauceDemoAutomation.Utilities
{
    // Base test class for initializing and tearing down the WebDriver
    internal class Base
    {
        /// <summary>
        /// Setup method runs before each test.
        /// It initializes the WebDriver based on browser config (default: Chrome).
        /// </summary>
        public IWebDriver driver = null!;
        string browserName = null!;

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

        /// <summary>
        /// Initializes the WebDriver instance based on specified browser.
        /// Supports Chrome, Edge, and Firefox.
        /// </summary>
        /// <param name="browserName">The name of the browser to initialize.</param>
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

                    // Disable Chrome password leak detection popup
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

        // Utility method to get a fresh instance of JsonReader for reading test data.
        public static JsonReader GetJsonData()
        {
            return new JsonReader();
        }

        // Cleanup method runs after each test.
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
