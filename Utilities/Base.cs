using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Configuration;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Core;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports.Model;

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

        private static ExtentReports extent;
        private static ExtentTest test;

        // Setup Extent Report once for all tests
        [OneTimeSetUp]
        public void SetupReports()
        {
            // Creates TestResults folder for storing HTML reports
            string reportDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestResults");
            Directory.CreateDirectory(reportDir);

            string timeStamp = DateTime.Now.ToString("yyyy/MM/dd_HH:mm:ss");
            var htmlReporter = new ExtentSparkReporter(Path.Combine(reportDir, $"TestsReport_{timeStamp}.html"));
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local Host");
        }

        [SetUp]
        public void Setup()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            browserName = TestContext.Parameters["browserName"];

            // Get browser name from App.config
            if (browserName == null)
            {
                browserName = ConfigurationManager.AppSettings["browser"];
            }
            InitBrowser(browserName);
            test.Info($"Test is running on browser: {browserName}");

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

                    // Disables Chrome password leak detection popup
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
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;

            DateTime time = DateTime.Now;
            string fileName = "Screenshot_" + time.ToString("yyyy/MM/dd_HH:mm:ss") + ".png";

            // Checks for tests status
            switch (status)
            {
                case TestStatus.Failed:
                    test.Fail("Test failed", CaptureScreenShot(driver, fileName));
                    test.Log(Status.Fail, "test failed with logtrace" + stackTrace);
                    break;
                case TestStatus.Passed:
                    test.Pass("Test passed");
                    break;
                case TestStatus.Skipped:
                    test.Skip("Test skipped");
                    break;
                default:
                    test.Warning("Test ended with unexpected status");
                    break;
            }
            driver?.Close();
            driver?.Dispose();
        }

        // Ensures the report always gets flushed
        [OneTimeTearDown]
        public void TearDownReport()
        {
            extent.Flush();
        }

        // Generates screenshot for reports
        public Media CaptureScreenShot(IWebDriver driver, string screenShotName)
        {
            ITakesScreenshot takesScreen = (ITakesScreenshot)driver;
            var screenShot = takesScreen.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenShot, screenShotName).Build();
        }
    }
}
