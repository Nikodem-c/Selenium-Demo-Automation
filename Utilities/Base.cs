using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Configuration;

namespace SauceDemoAutomation.Utilities
{
    internal class Base
    {
        public IWebDriver driver;
        string browserName;

        [SetUp]
        public void Setup()
        {
            if (browserName == null)
            {
                browserName = ConfigurationManager.AppSettings["browser"];
            }
            InitBrowser(browserName);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();

            driver.Url = "https://www.saucedemo.com/";
        }

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

        public IWebDriver GetDriver()
        {
            return driver;
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Close();
                driver.Dispose();
            }
        }
    }
}
