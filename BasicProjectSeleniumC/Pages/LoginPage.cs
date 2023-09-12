using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using BasicProjectSeleniumC.Helpers;

namespace BasicProjectSeleniumC.Pages
{
    public class LoginPage : Helper
    {
        #region Variables

        private readonly IWebDriver _driver;

        private readonly string urlHomePage = "https://sahitest.com/demo/training/login.htm";

        #endregion


        #region Locators
        public By UsernameTxt => By.Name("user");

        public By PasswordTxt => By.Name("password");

        public By LoginButton => By.XPath("//input[@type='submit']");

        #endregion

        public LoginPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }


        #region Actions

        public void OpenHomePage()
        {
            OpenPage(urlHomePage);

        }


        public void InputUsername(string username)
        {
            ClearFieldAndSentKeys(UsernameTxt, username);
        }

        public void InputPassword(string password)
        {
            ClearFieldAndSentKeys(PasswordTxt, password);
        }

        public void ClickLoginButton()
        {
            ClickElement(LoginButton);
        }

        #endregion


    }
}
