using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicProjectSeleniumC.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BasicProjectSeleniumC.TestCases
{
    [TestFixture]
    public class TestLogin
    {

        private readonly IWebDriver _driver;

        private readonly LoginPage _loginPage;

        public TestLogin()
        {
            _driver = new ChromeDriver();

            _loginPage = new LoginPage(_driver);
        }


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _loginPage.OpenHomePage();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void SuccessfullyLogin()
        {

            _loginPage.InputUsername("test");
            _loginPage.InputPassword("secret");
            _loginPage.ClickLoginButton();
        }

    }
}
