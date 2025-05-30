using SauceDemoAutomation.Utilities;
using OpenQA.Selenium;

namespace SauceDemoAutomation.Tests
{
    internal class End2End : Base
    {
        [Test]
        public void DemoTest()
        {

            GetDriver();
            driver.FindElement(By.Id("user-name")).SendKeys("1");
        }
    }
}
