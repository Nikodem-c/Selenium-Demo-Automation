using SauceDemoAutomation.Pages;
using SauceDemoAutomation.Utilities;

namespace SauceDemoAutomation.Tests
{
    // Smoke test suite covering core app functionality
    [Parallelizable(ParallelScope.All)]
    internal class Smoke : Base
    {
        // Verifies that the login page loads successfully and form elements are visible
        [Test, Category("Smoke")]
        public void LoginPageLoad()
        {
            var loginPage = new LoginPage(GetDriver());

            Assert.That(loginPage.IsLoginFormVisible(), Is.True);
        }

        // Logs in with valid credentials and verifies successful navigation to Products page
        [Test, TestCaseSource(nameof(ValidUserData)), Category("Smoke")]
        public void LoginStandardUser(string username, string password)
        {
            var loginPage = new LoginPage(GetDriver());
            ProductsPage productsPage = loginPage.Login(username, password);

            Assert.That(productsPage.ProductsPageUrl(), Is.True);
            Assert.That(productsPage.IsMenuIconVisible(), Is.True);
            Assert.That(productsPage.IsCartIconDisplayed(), Is.True);
            Assert.That(productsPage.GetProductsList(), Is.Not.Empty);
        }

        // Logs in and logs out, verifying return to the login page
        [Test, TestCaseSource(nameof(ValidUserData)), Category("Smoke")]
        public void Logout(string username, string password)
        {
            var loginPage = new LoginPage(GetDriver());
            ProductsPage productsPage = loginPage.Login(username, password);
            productsPage.GetLogout();

            Assert.That(loginPage.IsLoginFormVisible(), Is.True);
        }

        // Attempts to log in with a locked-out user and verifies that an error message is displayed
        [Test, TestCaseSource(nameof(LockedOutUserData)), Category("Negative")]
        public void LoginLockedOutUser(string username, string password)
        {
            var loginPage = new LoginPage(GetDriver());
            loginPage.AttemptLogin(username, password);

            Assert.That(loginPage.HasLoginError(), Is.True);
            Assert.That(loginPage.IsErrorVisible(), Is.True);
        }

        public static IEnumerable<TestCaseData> ValidUserData()
        {
            yield return new TestCaseData(GetJsonData().ExtractData("standard_user"), GetJsonData().ExtractData("password"));
        }

        public static IEnumerable<TestCaseData> LockedOutUserData()
        {
            yield return new TestCaseData(GetJsonData().ExtractData("locked_out_user"), GetJsonData().ExtractData("password"));
        }
    }
}
