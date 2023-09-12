using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace BasicProjectSeleniumC.Helpers
{

    public class Helper
    {
        private readonly IWebDriver _driver;

        public Helper(IWebDriver driver)
        {
            _driver = driver;

        }

        public bool IsElementVisible(By locator)
        {
            var isVisible = false;
            try
            {
                isVisible = WaitForElementUntilIsVisible(locator).Displayed;
            }
            catch (NoSuchElementException e)
            {
                isVisible = false;
            }
            catch (Exception e)
            {
                isVisible = false;
            }
            return isVisible;
        }

        public IWebElement WaitForElementUntilIsVisible(By locator, int seconds = 10)
        {
            var wait = new WebDriverWait(_driver, System.TimeSpan.FromSeconds(seconds));

            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));

            element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);

            return element;
        }

        public IWebElement WaitForElementUntilIsClickable(By locator, int seconds = 10)
        {
            var wait = new WebDriverWait(_driver, System.TimeSpan.FromSeconds(seconds));

            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);

            return element;
        }

        public void WaitSeconds(int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }

        public void ScrollToElement(By locator)
        {
            var element = _driver.FindElement(locator);
            Actions actions = new Actions(_driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public void Scroll(By locator)
        {
            _driver.FindElement(locator).SendKeys(Keys.ArrowDown);
        }

        public void OpenPage(string url)
        {
            _driver.Navigate().GoToUrl(url);

            _driver.Manage().Window.Maximize();
        }

        public void ClickElement(By locator)
        {
            WaitForElementUntilIsVisible(locator);

            ScrollToElement(locator);

            _driver.FindElement(locator).Click();
        }

        public void ClearFieldAndSentKeys(By locator, string text)
        {
            WaitForElementUntilIsVisible(locator);

            _driver.FindElement(locator).Click();

            _driver.FindElement(locator).SendKeys(Keys.Delete);

            _driver.FindElement(locator).SendKeys(text);

        }

        public string GetElementText(By locator)
        {
            string value = _driver.FindElement(locator).Text;

            return value;
        }

        public void SwitchToAWindow(int windowNumber)
        {
            _driver.SwitchTo().Window(_driver.WindowHandles[windowNumber]);
        }


    }
}
