using SauceDemoAutomation.Utilities;
using OpenQA.Selenium;
using SauceDemoAutomation.Pages;

namespace SauceDemoAutomation.Tests
{
    // End-to-end test class inheriting from Base class (browser setup/teardown)
    internal class End2End : Base
    {
        [Test, TestCaseSource("GetTestData"), Category("End2End")]
        public void EndToEnd(string username, string password)
        {
            LoginPage loginpage = new LoginPage(GetDriver());
            loginpage.Login(username, password);
        }

        /// <summary>
        /// Supplies test data (username & password) from external JSON file.
        /// </summary>
        /// <returns>TestCaseData object for NUnit parameterized test</returns>
        public static IEnumerable<TestCaseData> GetTestData()
        {
            yield return new TestCaseData(GetJsonData().ExtractData("standard_user"), GetJsonData().ExtractData("password"));
        }
    }
}
